import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderService } from '../../core/services/order.service';
import { ProductService } from '../../core/services/product.service';
import { Order, OrderItem } from '../../core/models/order.model';
import { Product } from '../../core/models/product.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
   imports: [FormsModule, CommonModule]
})
export class OrderDetailsComponent implements OnInit {
  order!: Order;
  products: Product[] = [];
  selectedProductId!: string;
  quantity: number = 1;

  constructor(
    private route: ActivatedRoute,
    private orderService: OrderService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    const orderId = this.route.snapshot.paramMap.get('id')!;
    this.loadOrder(orderId);
    this.loadProducts();
  }

  loadOrder(id: string) {
    this.orderService.getById(id).subscribe(o => this.order = o);
  }

  loadProducts() {
    this.productService.getAll().subscribe(p => this.products = p);
  }

  addItem() {
    if (!this.selectedProductId || this.quantity <= 0) return;
    this.orderService.addItem(this.order.id, this.selectedProductId, this.quantity)
      .subscribe(() => this.loadOrder(this.order.id));
  }

  completeOrder() {
    this.orderService.complete(this.order.id)
      .subscribe(() => this.loadOrder(this.order.id));
  }
}
