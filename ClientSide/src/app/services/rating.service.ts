import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rating } from '../models/rating.model';

@Injectable({
  providedIn: 'root'
})
export class RatingService {

  constructor(private http: HttpClient) { }

  private baseUrl: string = "https://localhost:7045/api/Rating";

  getUserProgramScore(username: string, programId: number) : Observable<Rating>{
    return this.http.get<Rating>(`${this.baseUrl}/getrating`, { params: { username, programId } });
  }
  putOrUpdateRating(userName: string, meditationProgramId: number, score: number){
    return this.http.put<any>(`${this.baseUrl}/change`, { userName, meditationProgramId, score });
  }
}
