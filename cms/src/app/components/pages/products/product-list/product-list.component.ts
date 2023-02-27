import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs';
import { Item } from 'src/app/models/item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-product-list-component',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent {
  headers = ['品名','單位(顆)','售價','備註',''];
  items: Item[] = [];

  constructor(
    private router: Router,
    private itemSrv: ItemService
  ) {

  }

  ngOnInit() {
    this.getProductList();
  }

  getProductList() {
    this.itemSrv.getItems().subscribe(items=>{
      this.items = items;
    });
  }

  doAdd() {
    this.router.navigate(['products/edit']);
  }

  doEdit(item: Item) {
    this.itemSrv.item = item;
    this.router.navigate(['products/edit']);
  }

  doDelete(Id: string) {
    this.itemSrv.deleteItem(Id).pipe(
      tap(x=> this.getProductList())
    ).subscribe();
  }
}
