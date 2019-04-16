import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';

/*import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})*/
@Injectable()
export class ProductService {
  private products=[
      {name:"Citramon", amount: 15, price:10.00  },
      {name:"No-shpa", amount: 20, price:50.00 },
      {name:"Nurofen", amount: 10, price:65.50 }
    ];
  constructor(private _httpClient: HttpClient) {

  }
    
  public getAll(){
    return this._httpClient.get<any[]>('http://localhost:52316/api/Medicine');
    //return this.products;
  }
  public add(name:string, amount:number, price:number){
    var prod = {name, amount, price}
    return this._httpClient.post<any>('http://localhost:52316/api/Medicine',prod);
  }
  public remove(id:number){
    return this._httpClient.delete<any>(`http://localhost:52316/api/Medicine/${id}`);
    //this.products = this.products.filter(pr=>pr.name!==name);
  }
}
