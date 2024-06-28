import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private http: HttpClient) { }

  private baseUrl: string = "https://localhost:7045/api/Category";

  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(this.baseUrl + "/getAll");
  }

  addCategory()
  {

  }

  deleteCategory(id:number): Observable<void>
  {
    return this.http.delete<void>(this.baseUrl+"/delete/"+id);
  }
}
