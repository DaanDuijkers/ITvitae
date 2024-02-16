import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ApiService
{
  constructor(private httpClient: HttpClient) { }

  HttpGet<T>(path: string): Observable<T>
  {
    return this.httpClient.get<T>(`${environment.apiUrl}/${path}`);
  }
}