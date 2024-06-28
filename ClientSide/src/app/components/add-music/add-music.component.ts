import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';
import { MusicService } from 'src/app/services/music.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-add-music',
  templateUrl: './add-music.component.html',
  styleUrls: ['./add-music.component.scss']
})
export class AddMusicComponent implements OnInit {
  constructor(
    private fb: FormBuilder, 
    private toast: ToastrService,
    private musicService: MusicService,
    private userStore: UserStoreService,
    private auth: AuthService,
    private router: Router ) { }
  musicform!: FormGroup;
  selectedFile: File | undefined;
  public fullName : string = "";

  ngOnInit(): void{
    this.musicform = this.fb.group({
      musicName: ['', Validators.required]
    });
    this.userStore.getFullNameFromStore().subscribe(val=>{
      const fullNameFromToken = this.auth.getFullNameFromToken();
      this.fullName = val || fullNameFromToken
    });
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0] as File;
  }

  addMusic(){
    if(this.musicform.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('userName', this.fullName);
      formData.append('name', this.musicform.get('musicName')?.value);
      formData.append('file', this.selectedFile, this.selectedFile.name);
      this.musicService.addMusic(formData).subscribe({
        next:(res) => {
          this.toast.success("Reset success!", "Success", {timeOut: 3000});
          this.router.navigate(['compositewrapper','timer']);
        },
        error:(err) => {
          this.toast.error("Something went wrong!", "ERROR", {timeOut: 2000});
          console.log(err)
        }
      })
    }
  }
}
