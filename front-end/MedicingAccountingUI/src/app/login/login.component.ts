import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {UserService} from '../user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  @Output() user =  new EventEmitter();
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
   this._userService.getByLogin(login, password)
        .subscribe(u => this._name ="Hello, " + u.name,
                        err=>console.log(err),
                        ()=>{  
                          if(this._name!=undefined) {
                          this.user.emit(this._name);
                          this._visible = false;
                          console.log(this._name);
                        }
                      }); 
  }
}
