import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

class User{
  id:number;
  name:string;
  login:string;
  password:string;
}
@Injectable()
export class UserService {

  constructor(private _httpClient: HttpClient) { }

  public getByLogin(login: string, password:string){
    var myQuery:string;
    const param1 = new HttpParams().set("login",login);
    const param2 = new HttpParams().set("password",password);
    var result = this._httpClient
                .get<User>(`http://localhost:52316/api/Users?`+param1+"&"+param2);
    return result;
  }
}