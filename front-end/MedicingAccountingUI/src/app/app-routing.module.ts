import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import {CheckAuthorizationGuard} from './check-authorization.guard';

const routes=[{path: '', component:LoginComponent},
              {path: 'products', component:ProductsComponent, canActivate: [CheckAuthorizationGuard]}]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
