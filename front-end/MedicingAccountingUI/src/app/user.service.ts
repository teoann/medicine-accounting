import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { HeaderComponent } from './header/header.component';
import {map} from 'rxjs/operators';

class User{
  id:number;
  name:string;
  login:string;
  password:string;
}

@Injectable()
export class UserService {
  
  private UserName = new BehaviorSubject('undefined');
  private _callbacs:any[]=[];

  currentName = this.UserName.asObservable();
  
  constructor(private _httpClient: HttpClient) { 
  }
  
  public subscribeNotification(name: string, callback:any) {
    this._callbacs.push({key:name, callback});
  }

  public unsubscribe(name: string) {
    this._callbacs = this._callbacs.filter(x=>x.key!==name);
  }

  public getByLogin(login: string, password:string){

    const param1 = new HttpParams().set("login",login);
    const param2 = new HttpParams().set("password",password);
    var res = this._httpClient
                .get<User>(`http://localhost:52316/api/Users?`+param1+"&"+param2)
                .subscribe(us=>(this.UserName.next(us.name)),(err)=>console.log(err),()=>{
        this.ChangedNameEmitter(this.UserName.getValue()); 
    });
    return res;  
  }

    public ChangedNameEmitter (name:any){
    this._callbacs.forEach(x => x.callback(name));
  }
  
}