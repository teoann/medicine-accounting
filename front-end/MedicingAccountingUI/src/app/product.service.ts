import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';

/*
@Injectable({
  providedIn: 'root'
})*/
@Injectable()
export class ProductService {

  constructor(private _httpClient: HttpClient) {
  }

  public getAll(){
    return this._httpClient.get<any[]>('http://localhost:52316/api/Medicine');
    //return this.products;
  }
  public add(name:string, amount:number, price:number){
    var prod = {name, amount, price};
    return this._httpClient.post<any>('http://localhost:52316/api/Medicine',prod);
  }
  public remove(id:number){
    return this._httpClient.delete<any>(`http://localhost:52316/api/Medicine/${id}`);
  }
}
