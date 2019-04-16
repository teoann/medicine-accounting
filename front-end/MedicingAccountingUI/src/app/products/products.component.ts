import { Component, OnInit, Injectable } from '@angular/core';
import {FormBuilder, Validators, FormGroup} from '@angular/forms';
import { Placeholder } from '@angular/compiler/src/i18n/i18n_ast';
import { ProductService } from '../product.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-products',
  styleUrls: ['./products.component.css'],
  templateUrl: './products.component.html'
})

export class ProductsComponent implements OnInit {
  addingProductForm: FormGroup;
  public products = [];
  constructor(private _productService: ProductService, 
              private formBuilder: FormBuilder) {
    this.addingProductForm = this.formBuilder.group({
      'productName':["", [Validators.required, Validators.pattern("([A-Za-z]+(\\s)?)+")]],
      'productAmount': [,[Validators.required, Validators.pattern("[0-9]+")]],
      'productPrice': [, [Validators.required, Validators.pattern("[0-9]+\\.?[0-9]{2}")]]
    });
//    this._productService = productService;
  } 
  ngOnInit() {
    this._productService.getAll().subscribe(x => this.products = x);
  }
  removeProduct(id:number){
   this._productService.remove(id).subscribe(
      res=>this.products = res,
      err=>console.log(err));
  }
  addProduct(name:string, amount:number, price:number){
    this._productService.add(name, amount, price).subscribe(
      ()=>(this._productService.getAll().subscribe(x => this.products = x)));
  }
}
