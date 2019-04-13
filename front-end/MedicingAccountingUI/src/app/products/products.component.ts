import { Component, OnInit, Injectable } from '@angular/core';
import {FormBuilder, Validators, FormGroup} from '@angular/forms';
import { Placeholder } from '@angular/compiler/src/i18n/i18n_ast';

@Component({
  selector: 'app-products',
  styleUrls: ['./products.component.css'],
  templateUrl: './products.component.html'
})

export class ProductsComponent implements OnInit {
  addingProductForm: FormGroup;
  constructor(private formBuilder: FormBuilder) {
    this.addingProductForm = formBuilder.group({
      'productName':["", [Validators.required, Validators.pattern("([A-Za-z]+(\\s)?)+")]],
      'productAmount': [,[Validators.required, Validators.pattern("[1-9]+")]],
      'productPrice': [, [Validators.required, Validators.pattern("[0-9]+\\.?[0-9]*")]]
    });
  } 

  ngOnInit() {
    
    
  }
  addProduct() {
    
  }
}
