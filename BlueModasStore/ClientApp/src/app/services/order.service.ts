import { Order } from '../models/order';
import { Item } from '../models/item';
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

  AddItem(productId, orderId, quantity): Observable<Order> {
    let httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    let options = {
      headers: httpHeaders
    }

    if (orderId === null)
      orderId = 0;
    else
      orderId = parseInt(orderId);

    return this.httpClient.post<Order>(`${this.baseUrl}Order/AddItem`,
      {
        productId: productId,
        orderId: orderId,
        quantity: quantity
      },
      options
    );
  }
}
