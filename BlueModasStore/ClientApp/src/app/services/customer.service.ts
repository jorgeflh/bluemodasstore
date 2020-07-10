import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private baseUrl;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  IdentifyCustomer(customer): Observable<boolean> {
    let httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    let options = {
      headers: httpHeaders
    }

    return this.httpClient.post<boolean>(`${this.baseUrl}Customer/IdentityCustomer`,
      {
        customer: customer,
      },
      options
    );
  }
}
