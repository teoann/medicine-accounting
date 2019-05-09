import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Input() user;
  
  constructor() {
   }

  ngOnInit() {
   if(this.user!=undefined) console.log(this.user);
  }

}
