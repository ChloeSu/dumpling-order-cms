import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderListComponent } from './components/pages/orders/order-list/order-list.component';
import { ProductListComponent } from './components/pages/products/product-list/product-list.component';
import { ProductEditComponent } from './components/pages/products/product-edit/product-edit.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/orders', pathMatch: 'full' },
  { path: 'orders', component: OrderListComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'products/edit', component: ProductEditComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
