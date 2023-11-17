import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  private baseUrl = 'https://safemed.azurewebsites.net/api';

  constructor(private http: HttpClient) { }

  loginRequest(data: any) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    const url = '/api/Login';
    return this.http.post<any>(url, data, { headers });
  }

}
