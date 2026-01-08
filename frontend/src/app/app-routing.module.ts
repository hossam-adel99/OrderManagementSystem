import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './products/product-list/product-list.component';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { OrderCreateComponent } from './orders/order-create/order-create.component';
import { OrderDetailsComponent } from './orders/order-details/order-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'products', pathMatch: 'full' },
  { path: 'products', component: ProductListComponent },
  { path: 'orders', component: OrderListComponent },
  { path: 'orders/new', component: OrderCreateComponent },
  { path: 'orders/:id', component: OrderDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
