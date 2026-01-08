import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'https://localhost:7067/api/orders';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Order[]> {
    return this.http.get<Order[]>(this.apiUrl);
  }

  getById(orderId: string): Observable<Order> {
    return this.http.get<Order>(`${this.apiUrl}/${orderId}`);
  }

  create(customerId: string): Observable<Order> {
    return this.http.post<Order>(this.apiUrl, { customerId });
  }

  addItem(orderId: string, productId: string, quantity: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/${orderId}/items`, { orderId, productId, quantity });
  }

  complete(orderId: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/${orderId}/complete`, {});
  }
}
