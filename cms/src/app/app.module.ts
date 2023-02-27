import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ProductListComponent } from './components/pages/products/product-list/product-list.component';
import { ProductEditComponent } from './components/pages/products/product-edit/product-edit.component';
import { LoadInterceptorService } from './interceptors/load-interceptor.service';
import { LoaderComponent } from './components/shared/loader/loader.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrderListComponent } from './components/pages/orders/order-list/order-list.component';
import { OrderEditComponent } from './components/pages/orders/order-edit/order-edit.component';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoaderComponent,
    OrderListComponent,
    OrderEditComponent,
    ProductListComponent,
    ProductEditComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  exports: [

  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: LoadInterceptorService,
    multi: true
  }],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas);
  }
}
