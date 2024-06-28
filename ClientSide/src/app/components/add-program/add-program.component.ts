import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Meditation } from 'src/app/models/meditation.model';
import { AuthService } from 'src/app/services/auth.service';
import { MeditationProgramService } from 'src/app/services/meditation-program.service';
import { MeditationService } from 'src/app/services/meditation.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-add-program',
  templateUrl: './add-program.component.html',
  styleUrls: ['./add-program.component.scss']
})
export class AddProgramComponent implements OnInit {
  constructor(
    private fb: FormBuilder, 
    private toast: ToastrService,
    private programService: MeditationProgramService,
    private meditationService: MeditationService,
    private userStore: UserStoreService,
     private auth: AuthService,
    private router: Router ) { }
  programform!: FormGroup;
  selectedFile: File | undefined;
  meditations: Meditation[] = [];
  public role!:string;

  ngOnInit(): void{
    this.userStore.getRoleFromStore().subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    });
    this.getAllMeditations();
    this.programform = this.fb.group({
      programName: ['', Validators.required],
      meditationId: [null, Validators.required]
    });
  }
  getAllMeditations(){
    this.meditationService.getAllMeditations().subscribe({
      next: (res) => {
        this.meditations = res;
      },
      error:(err) => {
        this.toast.error("Something went wrong!", "ERROR", {timeOut: 3000});
      },
    })
   }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0] as File;
  }

  addProgram(){
    if(this.programform.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('meditationId',  this.programform.get('meditationId')?.value.toString());
      formData.append('programName', this.programform.get('programName')?.value);
      formData.append('file', this.selectedFile, this.selectedFile.name);
      this.programService.addMeditationProgram(formData).subscribe({
        next:(res) => {
          this.toast.success("Reset success!", "Success", {timeOut: 3000});
          this.router.navigate(['compositewrapper']);
        },
        error:(err) => {
          this.toast.error("Something went wrong!", "ERROR", {timeOut: 2000});
          console.log(err)
        }
      })
    }else{
      console.log("Поля пусті")
    }
  }
}
