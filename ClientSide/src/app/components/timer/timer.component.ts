import { Component, OnInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Music } from 'src/app/models/music.model';
import { AuthService } from 'src/app/services/auth.service';
import { MusicService } from 'src/app/services/music.service';
import { UserStoreService } from 'src/app/services/user-store.service';


@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']

})
export class TimerComponent implements OnInit, OnDestroy{
  public fullName : string = "";
  public role!:string;

  public musicList: Music[] = [];
  selectedContent: Music | null = null;
  private musicaudio = new Audio();
  
  public hours: number = 0;
  public minutes: number = 0;
  public seconds: number = 0;
  private timer: any;
  private date = new Date();
  
  public show: boolean = true;
  public disabled: boolean = false;
  public animate: boolean = false;
  @ViewChild("idAudio") idAudio!: ElementRef;

  constructor(
    private router: Router, 
    private userStore: UserStoreService, 
    private auth: AuthService,
    private toast: ToastrService,
    private musicService: MusicService
  ) { }

  ngOnInit() {
    this.userStore.getFullNameFromStore().subscribe(val=>{
      const fullNameFromToken = this.auth.getFullNameFromToken();
      this.fullName = val || fullNameFromToken
    });
    this.userStore.getRoleFromStore().subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })
    this.musicService.getAllUserMusic(this.fullName).subscribe({
      next: (res) => {
        this.musicList = res;
      },
    });
  }
  ngOnDestroy(){
    if (this.musicaudio) {
      this.musicaudio.pause(); // Зупинка аудіо
      this.musicaudio.src = ''; // Очистка джерела аудіо
      this.musicaudio.load(); // Перезавантаження аудіо елементу
    }
  }

  increment(type: 'H' | 'M' | 'S') {
    if (type === 'H') {
      if (this.hours >= 99) return;
      this.hours += 1;
    }
    else if (type === 'M') {
      if (this.minutes >= 59) return;
      this.minutes += 1;
    }
    else {
      if (this.seconds >= 59) return;
      this.seconds += 1;
    }
  }
  decrement(type: 'H' | 'M' | 'S') {
    if (type === 'H') {
      if (this.hours <= 0) return;
      this.hours -= 1;
    }
    else if (type === 'M') {
      if (this.minutes <= 0) return;
      this.minutes -= 1;
    }
    else {
      if (this.seconds <= 0) return;
      this.seconds -= 1;
    }
  }

  updateTimer() {
    this.date.setHours(this.hours);
    this.date.setMinutes(this.minutes);
    this.date.setSeconds(this.seconds);
    this.date.setMilliseconds(0);
    const time = this.date.getTime();
    this.date.setTime(time - 1000);
    this.hours = this.date.getHours();
    this.minutes = this.date.getMinutes();
    this.seconds = this.date.getSeconds();
    if (this.date.getHours() === 0 &&
      this.date.getMinutes() === 0 &&
      this.date.getSeconds() === 0) {
      this.pauseAudio();
      //stop interval
      clearInterval(this.timer);
      this.idAudio.nativeElement.play();
      this.animate = true;
      setTimeout(() => {
        this.stop();
        this.idAudio.nativeElement.load();
      }, 5000);
    }
  }

  start() {
    if (this.hours > 0 || this.minutes > 0 || this.seconds > 0) {
      this.disabled = true;
      this.show = false;  //hide btn + and -
      this.updateTimer();
      this.playAudio();
      if(this.seconds > 0){
        this.timer = setInterval(() => {
          this.updateTimer();
        }, 1000);
      }     
    }
  }

  stop() {    
    this.disabled = false;
    this.show = true;
    this.animate = false;
    clearInterval(this.timer);
    this.idAudio.nativeElement.load();
    this.pauseAudio();
  }

  reset() {
    this.hours = 0;
    this.minutes = 0;
    this.seconds = 0;
    this.stop();
  }

  playAudio() {
    if (this.musicaudio) {
      this.musicaudio.play();
    }
  }

  pauseAudio() {
    this.musicaudio.pause();
  }

  onContentChange(content: Music) {
    if (content === null) {
      this.selectedContent = null;
      this.musicaudio.src = '';
    }
    else{
      this.selectedContent = content;
      this.musicaudio.src = content.s3UrlAudio;
      this.musicaudio.load();
      this.musicaudio.loop = true;
      console.log('currentTime:',this.musicaudio.currentTime);
    }
  }


  addMusic(){
    if(this.role == "User"){
      this.router.navigate(['compositewrapper','add-music']);
    }
  }

  deleteSelectMusic(){
    if(this.selectedContent){
      this.musicService.deleteMusic(this.selectedContent.id).subscribe({
        next:(res) => {
          this.toast.success("Reset success!", "Success", {timeOut: 3000});
          this.musicList = this.musicList.filter(music => music.id !== this.selectedContent?.id);
        },
        error:(err) => {
          this.toast.error("Something went wrong!", "ERROR", {timeOut: 2000});
          console.log(err)
        }
      })
    }
  }
}
