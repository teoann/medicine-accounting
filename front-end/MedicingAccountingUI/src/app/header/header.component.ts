import { Component, OnInit} from '@angular/core';
import {UserService} from '../user.service'

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public userName: string  = 'undefined';

  constructor(private US: UserService) {}

  ngOnInit() {
    this.US.subscribeNotification('header', 
      ()=>this.US.currentName.subscribe(us=> this.userName =us));
    console.log(this.userName);
  }
   
}

