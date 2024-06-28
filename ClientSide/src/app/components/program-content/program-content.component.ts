import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MeditationProgram } from 'src/app/models/meditation-program.model';
import { ProgramContent } from 'src/app/models/program-content.model';
import { MeditationProgramService } from 'src/app/services/meditation-program.service';
import { faStar } from '@fortawesome/free-solid-svg-icons/faStar';
import { RatingService } from 'src/app/services/rating.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { AuthService } from 'src/app/services/auth.service';
import { Rating } from 'src/app/models/rating.model';
import { MeditationPrograms } from 'src/app/models/meditation-programs.model';

@Component({
  selector: 'app-program-content',
  templateUrl: './program-content.component.html',
  styleUrls: ['./program-content.component.scss']
})
export class ProgramContentComponent implements OnInit, OnDestroy{
  program!: MeditationProgram;
  programId!: number;
  recomendedPrograms!: MeditationPrograms[];
  public role!:string;
  public fullName : string = "";

  selectedAudio: ProgramContent | any;
  currentTime: number = 0;
  duration: number = 0;
  private audio: HTMLAudioElement | any;

  faStar = faStar;
  rating: number = 0;
  getrating!: Rating; 

  constructor(
    private activrouter: ActivatedRoute,
    private meditationProgramService: MeditationProgramService,
    private ratingService: RatingService,
    private userStore: UserStoreService,
    private auth: AuthService,
    private toast: ToastrService,
    private router: Router
  ) { }

  ngOnInit(){
    this.userStore.getFullNameFromStore().subscribe(val=>{
      const fullNameFromToken = this.auth.getFullNameFromToken();
      this.fullName = val || fullNameFromToken
    });
    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })
    this.activrouter.params.subscribe(params => {
      this.programId = params['id'];
      this.getProgramWithContent(this.programId);
      this.getRecomends(this.fullName, this.programId);
    });
    this.ratingService.getUserProgramScore(this.fullName,this.programId).subscribe(val=>{
      this.rating = val.score;
    });

  }
  ngOnDestroy(){
    if (this.audio) {
      this.audio.pause(); // Зупинка аудіо
      this.audio.src = ''; // Очистка джерела аудіо
      this.audio.load(); // Перезавантаження аудіо елементу
    }
  }
  addContent(){
    if(this.role == "Admin"){
      this.router.navigate(['compositewrapper','add-program-content', this.programId]);
    }
  }
  setRating(value: number) {
    this.rating = value;
    this.ratingService.putOrUpdateRating(this.fullName,this.programId,value).subscribe({
      next: (res) => {
        
      },
      error:(err) => {
        this.toast.error("Something went wrong!", "ERROR", {timeOut: 3000});
      },
    })
  }

  getProgramWithContent(meditId: number){
    // отримуємо ім'я медитації для відображення назви, опису та тривалості
    this.meditationProgramService.getByIdContent(meditId).subscribe({
      next: (res) => {
        this.program = res;
      },
      error:(err) => {
        this.toast.error("Something went wrong!", "ERROR", {timeOut: 3000});
      },
    })
  }
  getRecomends(username: string, meditationProgramId: number){
    this.meditationProgramService.getRecomendations(username, meditationProgramId).subscribe({
      next: (res) => {
        this.recomendedPrograms = res;
      },
      error:(err) => {
        this.toast.error("Something went wrong!", "ERROR", {timeOut: 3000});
      },
    })
  }
  showSessions(sessionId: number){
    this.router.navigate(['compositewrapper','program-content', sessionId]);
   }

  onAudioSelect(content: ProgramContent): void {
    if (this.audio) {
      this.audio.pause();
    }
    this.selectedAudio = content;
    this.currentTime = 0;
    this.audio = new Audio(this.selectedAudio.s3UrlAudio);
    this.audio.addEventListener('loadedmetadata', () => {
      this.duration = this.audio!.duration;
    });
    this.audio.addEventListener('timeupdate', () => {
      this.currentTime = this.audio!.currentTime;
    });
    this.audio.play();
  }

  onTimeChange(event: any): void {
    const newTime = (event.target as HTMLInputElement).valueAsNumber;
    console.log('Slider value:', newTime);

    if (this.audio && typeof newTime === 'number' && !isNaN(newTime) && isFinite(newTime)) {
      this.audio.currentTime = newTime;
      console.log('Updated currentTime:', this.audio.currentTime);
    } else {
      console.error('Invalid time value:', newTime);
    }
  }

  start(){
    if (this.audio) {
      this.audio.play();
    }
  }
  stop(){
    if (this.audio) {
      this.audio.pause();
    }
  }
}
