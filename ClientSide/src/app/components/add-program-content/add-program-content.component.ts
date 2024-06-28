import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';
import { ProgramContentService } from 'src/app/services/program-content.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-add-program-content',
  templateUrl: './add-program-content.component.html',
  styleUrls: ['./add-program-content.component.scss']
})
export class AddProgramContentComponent implements OnInit {
  constructor(
    private activrouter: ActivatedRoute,
    private fb: FormBuilder, 
    private toast: ToastrService,
    private userStore: UserStoreService,
    private auth: AuthService,
    private programContentService: ProgramContentService,
    private router: Router ) { }
  contentForm!: FormGroup;
  selectedFile: File | undefined;
  programId!: number;
  public role!:string;
  public fullName : string = "";
  audioDuration!: number;


  ngOnInit(): void{
    this.contentForm = this.fb.group({
      contentName: ['', Validators.required]
    });
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
    });
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0] as File;
    if (this.selectedFile) {
      this.getAudioDuration(this.selectedFile);
    }
  }
  getAudioDuration(file: File) {
    const audio = new Audio(URL.createObjectURL(file));
    audio.addEventListener('loadedmetadata', () => {
      this.audioDuration = audio.duration;
      URL.revokeObjectURL(audio.src);
    });
  }

  addProgramContent(){
    if(this.contentForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('contentName', this.contentForm.get('contentName')?.value);
      formData.append('duration', this.transform(this.audioDuration));
      formData.append('meditationProgramId', this.programId.toString());
      formData.append('file', this.selectedFile, this.selectedFile.name);
      this.programContentService.addProgramContent(formData).subscribe({
        next:(res) => {
          this.toast.success("Reset success!", "Success", {timeOut: 3000});
          this.router.navigate(['compositewrapper','dashboard']);
        },
        error:(err) => {
          this.toast.error("Something went wrong!", "ERROR", {timeOut: 2000});
          console.log(err)
        }
      })
    }
  }

  transform(value: number): string {
    const minutes: number = Math.floor(value / 60);
    const seconds: number = Math.floor(value % 60);
    return `${this.pad(minutes)}:${this.pad(seconds)}`;
  }

  pad(num: number): string {
    return num < 10 ? '0' + num : num.toString();
  }
}
