import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { tap } from 'rxjs';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-product-edit-component',
  templateUrl: './product-edit.component.html'
})
export class ProductEditComponent {

  form:any;
  isAdd = true;

  constructor(
    private fb: FormBuilder,
    private itemSrv: ItemService
  ) {
    this.buildForm();
  }

  ngOnInit() {
    this.getInitData();
  }

  ngOnDestroy() {
    this.itemSrv.item = undefined;
  }

  buildForm() {
    this.form = this.fb.group({
      id: '',
      name: ['', Validators.required],
      unit: ['', Validators.required],
      price: ['', Validators.required],
      memo: ['']
    });
  }

  getInitData() {
    if(this.itemSrv.item) {
      this.form.patchValue(this.itemSrv.item);
      this.isAdd = false;
    }
  }

  doEdit() {
    const postdata = this.form.value;
    const req = this.isAdd ? this.itemSrv.addItem(postdata) : this.itemSrv.updateItem(postdata);
    req.pipe(
      tap(x=> this.back())
    ).subscribe();
  }

  doDelete() {
    this.itemSrv.deleteItem(this.form.value.id).pipe(
      tap(x=> this.back())
    ).subscribe();
  }

  back() {
    window.history.back();
  }
}
