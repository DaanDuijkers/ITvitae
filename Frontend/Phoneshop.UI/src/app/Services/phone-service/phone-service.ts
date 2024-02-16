import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Phone from 'src/app/models/Phone';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})

export class PhoneService
{
  constructor(private apiService: ApiService) { }

  getPhones(): Observable<Phone[]>
  {
    return this.apiService.HttpGet<Phone[]>("api/phone/httpget/getphones");
  }

  getPhoneById(id: number): Observable<Phone>
  {
    return this.apiService.HttpGet<Phone>("api/phone/httpget/get?id=" + id);
  }
}