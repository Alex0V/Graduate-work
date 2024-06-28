import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProgramContentService {

  constructor(private http: HttpClient) { }

  private baseUrl: string = "https://localhost:7045/api/ProgramContent";

  deleteProgramContent(id: number): Observable<void>
  {
    return this.http.delete<void>(`${this.baseUrl}/delete/"${id}`);
  }

  addProgramContent(contentObj:any): Observable<any>
  {
    return this.http.post<any>(this.baseUrl + "/add", contentObj);
  }
}
