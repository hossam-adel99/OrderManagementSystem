import { Component } from '@angular/core';
import { OrderService } from '../../core/services/order.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-order-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './order-create.component.html'
})

export class OrderCreateComponent {
  customerId = '';

  constructor(
    private orderService: OrderService,
    private router: Router
  ) {}

  create() {
    this.orderService.create(this.customerId).subscribe(() => {
      this.router.navigate(['/orders']);
    });
  }
}
