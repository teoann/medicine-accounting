import { Component, OnInit} from '@angular/core';
import {UserService} from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  private _name: string;
  private _visible: boolean;
  
  constructor(private _userService: UserService) { }

  ngOnInit() {
    this._visible = true;   
    if(this._name === undefined) {
      this._name="Log in, please";
    }
  }

Authorization(login:string, password:string){
  this._userService.getByLogin(login, password);
  this._userService.currentName.subscribe(
    name=> 
    {
      this._name = "Hello, "+name;
      this._visible = false;
    });  
} 

}
