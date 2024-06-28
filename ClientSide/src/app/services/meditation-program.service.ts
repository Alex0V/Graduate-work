import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MeditationPrograms } from '../models/meditation-programs.model';
import { Observable } from 'rxjs';
import { MeditationProgram } from '../models/meditation-program.model';

@Injectable({
  providedIn: 'root'
})
export class MeditationProgramService {
  constructor(private http: HttpClient) { }

  private baseUrl: string = "https://localhost:7045/api/MeditationProgram";

  getAllMeditations() : Observable<MeditationPrograms[]>
  {
    return this.http.get<MeditationPrograms[]>(this.baseUrl + "/all");
  }

  addMeditationProgram(meditObj:any)
  {
    return this.http.post<any>(this.baseUrl + "/add", meditObj);
  }

  deleteMeditationProgram(id:number) : Observable<void> {
    return this.http.delete<void>(this.baseUrl + "/delete/" + id);
  }

  getByIdContent(id:number){
    return this.http.get<MeditationProgram>(this.baseUrl + "/getbyid/" + id);
  }

  getRecomendations(username: string, meditationProgramId: number) : Observable<MeditationPrograms[]>{
    return this.http.get<MeditationPrograms[]>(this.baseUrl + "/getrecomendation", { params: { username, meditationProgramId } });
  }
}
