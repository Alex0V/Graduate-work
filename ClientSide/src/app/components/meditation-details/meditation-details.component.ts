import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Meditation } from 'src/app/models/meditation.model';
import { AuthService } from 'src/app/services/auth.service';
import { MeditationService } from 'src/app/services/meditation.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-meditation-details',
  templateUrl: './meditation-details.component.html',
  styleUrls: ['./meditation-details.component.scss']
})
export class MeditationDetailsComponent implements OnInit{
  meditation!: Meditation;
  meditId!: number;
  public role!:string;
  public fullName : string = "";

  constructor(
    private activrouter: ActivatedRoute,
    private meditServer: MeditationService,
    private userStore: UserStoreService,
     private auth: AuthService,
    private toast: ToastrService,
    private router: Router
  ) { }

  ngOnInit(){
    this.activrouter.params.subscribe(params => {
      this.meditId = params['id'];
      this.getMeditation(this.meditId);
    });
    
    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })
  }

  getMeditation(meditId: number){
    // отримуємо ім'я медитації для відображення назви, опису та тривалості
    this.meditServer.getByIdMeditation(meditId).subscribe({
      next: (res) => {
        this.meditation = res;
      },
      error:(err) => {
        this.toast.error("Something went wrong!", "ERROR", {timeOut: 3000});
      },
    })
  }
  deleteMeditation(){

  }
}
