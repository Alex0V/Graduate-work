import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { ResetComponent } from './components/reset/reset.component';
import { HomeComponent } from './components/home/home.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { BodyComponent } from './components/body/body.component';
import { CompositeWrapperComponent } from './components/composite-wrapper/composite-wrapper.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from "@angular/material/toolbar";
import { TimerComponent } from './components/timer/timer.component';
import { MeditationsComponent } from './components/meditations/meditations.component';
import { MeditationDetailsComponent } from './components/meditation-details/meditation-details.component';
import { ProgramsComponent } from './components/programs/programs.component';
import { TruncateTextPipe } from './truncate-text.pipe';
import { MatIconModule } from '@angular/material/icon';
import { MeditationProgramsComponent } from './components/meditation-programs/meditation-programs.component';
import { ProgramContentComponent } from './components/program-content/program-content.component'
import { MatSliderModule } from '@angular/material/slider';
import { MatChipsModule } from '@angular/material/chips';
import { MatListModule } from '@angular/material/list';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { SgTimePipe } from './sgTime.pipe';
import { AddMusicComponent } from './components/add-music/add-music.component';
import { AddMeditationComponent } from './components/add-meditation/add-meditation.component';
import { AddProgramComponent } from './components/add-program/add-program.component';
import { AddProgramContentComponent } from './components/add-program-content/add-program-content.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    ResetComponent,
    HomeComponent,
    SidenavComponent,
    BodyComponent,
    CompositeWrapperComponent,
    TimerComponent,
    MeditationsComponent,
    MeditationDetailsComponent,
    ProgramsComponent,
    MeditationProgramsComponent,
    TruncateTextPipe,
    SgTimePipe,
    ProgramContentComponent,
    AddMusicComponent,
    AddMeditationComponent,
    AddProgramComponent,
    AddProgramContentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    ToastrModule.forRoot(),
    
    // * MATERIAL IMPORTS
    MatDialogModule,
    MatCardModule,
    MatFormFieldModule, 
    MatSelectModule, 
    MatInputModule,
    MatToolbarModule,
    MatIconModule,
    MatSliderModule,
    MatListModule,
    MatProgressBarModule,
    FontAwesomeModule,
    MatChipsModule
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
