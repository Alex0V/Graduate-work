import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { MeditationService } from 'src/app/services/meditation.service';

@Component({
  selector: 'app-add-meditation',
  templateUrl: './add-meditation.component.html',
  styleUrls: ['./add-meditation.component.scss']
})
export class AddMeditationComponent implements OnInit {
  constructor(
    private fb: FormBuilder, 
    private toast: ToastrService,
    private meditationService: MeditationService,
    private categoryService: CategoryService,
    private router: Router ) { }
  meditationForm!: FormGroup;
  selectedFile: File | undefined;
  categories: Category[] = []; 
  myfilename = 'Select File';


  ngOnInit(): void{
    this.meditationForm = this.fb.group({
      meditationName: ['', Validators.required],
      meditationDescription: ['', Validators.required],
      meditationDuration: ['', Validators.required],
      selectedCategories: [[], Validators.required]
    });
    this.getAllCategories();
  }
  getAllCategories(){
    this.categoryService.getCategories().subscribe({
      next: (res) => {
        this.categories = res;
      },
      error:(err) => {
        this.toast.error("Something went wrong!", "ERROR", {timeOut: 3000});
      },
    })
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0] as File;
  }

  addMeditation(){
    if(this.meditationForm.valid && this.selectedFile) {
      const formData = new FormData();
      formData.append('name', this.meditationForm.get('meditationName')?.value);
      formData.append('description', this.meditationForm.get('meditationDescription')?.value);
      formData.append('duration', this.meditationForm.get('meditationDuration')?.value);
      formData.append('categoriesId',this.meditationForm.get('selectedCategories')?.value);
      formData.append('file', this.selectedFile, this.selectedFile.name);
      this.meditationService.addMeditation(formData).subscribe({
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
}
