import { ProductsComponent } from './products/products.component';

/*import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})*/
export class ProductService {
  private products=[
      {name:"Citramon", amount: 15, price:10.00  },
      {name:"No-shpa", amount: 20, price:50.00 },
      {name:"Nurofen", amount: 10, price:65.50 }
    ];
  constructor() { }
    public getAll(){
      return this.products;
    }
    public add(name:string, amount:number, price:number){
      this.products.push({name, amount, price});
    }
    public remove(name:string){
      this.products = this.products.filter(pr=>pr.name!==name);
    }
}
