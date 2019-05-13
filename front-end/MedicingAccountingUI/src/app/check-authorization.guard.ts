import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { CanActivate } from '@angular/router';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})

export class CheckAuthorizationGuard implements CanActivate{
  private userName: string='undefined';
  private isName:boolean;
  
  constructor(private US:UserService){

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) : Observable<boolean> | boolean{
    this.US.currentName.subscribe(us=> this.userName =us);
    if(this.userName=='undefined'){
      alert('You are not authorized yet');
      console.log(this.userName);
      this.isName = false;
    }
    else this.isName = true;
    
    return this.isName;
  }
  
}