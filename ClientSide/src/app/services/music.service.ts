import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Music } from '../models/music.model';

@Injectable({
  providedIn: 'root'
})
export class MusicService {

  constructor(private http: HttpClient) { }

  private baseUrl: string = "https://localhost:7045/api/Music";

  getAllUserMusic(userName: string): Observable<Music[]>
  {
    let params = new HttpParams().set('userName', userName);
    return this.http.get<Music[]>(`${this.baseUrl}/user`, { params });
  }

  deleteMusic(id: number): Observable<void>
  {
    console.log("work")
    console.log(id)
    return this.http.delete<void>(this.baseUrl+"/delete/"+id);
  }

  addMusic(musicObj:any): Observable<any>
  {
    return this.http.post<any>(this.baseUrl + "/add", musicObj);
  }
  
}
