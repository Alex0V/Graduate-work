import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { AuthGuard } from './guards/auth.guard';
import { ResetComponent } from './components/reset/reset.component';
import { HomeComponent } from './components/home/home.component';
import { CompositeWrapperComponent } from './components/composite-wrapper/composite-wrapper.component';
import { TimerComponent } from './components/timer/timer.component';
import { MeditationsComponent } from './components/meditations/meditations.component';
import { MeditationDetailsComponent } from './components/meditation-details/meditation-details.component';
import { MeditationProgramsComponent } from './components/meditation-programs/meditation-programs.component';
import { ProgramContentComponent } from './components/program-content/program-content.component';
import { AddMusicComponent } from './components/add-music/add-music.component';
import { AddMeditationComponent } from './components/add-meditation/add-meditation.component';
import { AddProgramComponent } from './components/add-program/add-program.component';
import { AddProgramContentComponent } from './components/add-program-content/add-program-content.component';


const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'signup', component: SignupComponent},
  {path: 'reset', component: ResetComponent},
  {path: 'compositewrapper', component: CompositeWrapperComponent, canActivate: [AuthGuard], children:[
    {path: '', redirectTo: 'programs', pathMatch: 'full' },
    {path: 'timer', component: TimerComponent, canActivate: [AuthGuard]},
    {path: 'meditations', component: MeditationsComponent, canActivate: [AuthGuard]},
    {path: 'meditation-details/:id', component: MeditationDetailsComponent, canActivate: [AuthGuard]},
    {path: 'programs', component: MeditationProgramsComponent, canActivate: [AuthGuard]},
    {path: 'program-content/:id', component: ProgramContentComponent, canActivate: [AuthGuard]},
    {path: 'add-meditation', component: AddMeditationComponent, canActivate: [AuthGuard]},
    {path: 'add-program', component: AddProgramComponent, canActivate: [AuthGuard]},
    {path: 'add-program-content/:id', component: AddProgramContentComponent, canActivate: [AuthGuard]},
    {path: 'add-music', component: AddMusicComponent, canActivate: [AuthGuard]},
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
