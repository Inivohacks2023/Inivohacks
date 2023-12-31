
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ScanApiService {

  private baseUrl = 'https://safemed.azurewebsites.net'
  constructor(private httpClient: HttpClient) { }

  


  requestTransfer(data: any) {
    

    const headers = new HttpHeaders({
      'responseType': 'text',
    });
    const url = this.baseUrl+'/api/Scan/RequestTransfer';
    return this.httpClient.post<any>(url, data, { headers });
  }

  acceptTransfer(data: any) {


    const headers = new HttpHeaders({
      'responseType': 'text',
    });
    const url = this.baseUrl + '/api/Scan/AcceptTransfer';
    return this.httpClient.post<any>(url, data, { headers });
  }

  getproducts() {


    const headers = new HttpHeaders({
      'responseType': 'text',
    });
    const url = this.baseUrl + '/api/Product/ProductList';
    return this.httpClient.get<any>(url);
  }


  getDetails(id:any) {


    const headers = new HttpHeaders({
      'responseType': 'text',
    });
    const url = 'https://safemed.azurewebsites.net/api/Scan/ScanForDetails?TrackingCodeID=00000001-0070-0001-0102-030405060708';
    debugger;
    return this.httpClient.get<any>(url);
  }

}


