import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private baseUrl;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  IdentifyCustomer(customer): Observable<Customer> {
    let httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    let options = {
      headers: httpHeaders
    }
    console.log(customer);
    return this.httpClient.post<Customer>(`${this.baseUrl}Customer/IdentifyCustomer`,
      {
        name: customer.name,
        email: customer.email,
        phone: customer.phone
      },
      options
    );
  }
}
