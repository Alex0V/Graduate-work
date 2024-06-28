import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MeditationPrograms } from 'src/app/models/meditation-programs.model';
import { AuthService } from 'src/app/services/auth.service';
import { MeditationProgramService } from 'src/app/services/meditation-program.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-meditation-programs',
  templateUrl: './meditation-programs.component.html',
  styleUrls: ['./meditation-programs.component.scss']
})
export class MeditationProgramsComponent implements OnInit {
  meditationPrograms: MeditationPrograms[] = [];

  public role!:string;
  public fullName : string = "";
  
  constructor(private meditProgramsService: MeditationProgramService, private toast: ToastrService, private router: Router, private userStore: UserStoreService, private auth: AuthService) { }
   ngOnInit() {
    this.getAllSGroup();

    this.userStore.getFullNameFromStore()
    .subscribe(val=>{
      const fullNameFromToken = this.auth.getFullNameFromToken();
      this.fullName = val || fullNameFromToken
    });

    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })
   }
   getAllSGroup(){
    this.meditProgramsService.getAllMeditations().subscribe({
      next: (res) => {
        this.meditationPrograms = res;
      },
      error:(err) => {
        this.toast.error("Something went wrong!", "ERROR", {timeOut: 3000});
      },
    })
   }

   showSessions(sessionId: number){
    this.router.navigate(['compositewrapper','program-content', sessionId]);
   }
   goToAdd(){
    if(this.role == "Admin"){
      this.router.navigate(['compositewrapper','add-program']);
    }
   }
}
