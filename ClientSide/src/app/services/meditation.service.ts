import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meditation } from '../models/meditation.model';

@Injectable({
  providedIn: 'root'
})
export class MeditationService {
  constructor(private http: HttpClient) { }

  private baseUrl: string = "https://localhost:7045/api/Meditation";

  getAllMeditations() : Observable<Meditation[]>
  {
    return this.http.get<Meditation[]>(this.baseUrl + "/all");
  }

  addMeditation(meditObj:any)
  {
    return this.http.post<any>(this.baseUrl + "/add", meditObj);
  }

  deleteMeditation(id:number) : Observable<void> {
    return this.http.delete<void>(this.baseUrl + "/delete/" + id);
  }

  getByIdMeditation(id:number){
    return this.http.get<Meditation>(this.baseUrl + "/getbyid/" + id);
  }
}
