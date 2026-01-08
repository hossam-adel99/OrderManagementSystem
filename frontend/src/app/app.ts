import { Component } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, FormsModule],
  template: `
    <h1>Order Management System</h1>
    <nav>
      <a routerLink="/products">Products</a> |
      <a routerLink="/orders">Orders</a> |
      <a routerLink="/orders/create">Create Order</a>
    </nav>
    <hr />
    <router-outlet></router-outlet>
  `
})
export class AppComponent {}
