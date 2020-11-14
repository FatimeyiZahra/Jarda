import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { MyAccountComponent } from './my-account/my-account.component';
import { FavoriteComponent } from './favorite/favorite.component';
import { CouponsComponent } from './coupons/coupons.component';


@NgModule({
  declarations: [AccountComponent, MyAccountComponent, FavoriteComponent, CouponsComponent],
  imports: [
    CommonModule,
    AccountRoutingModule
  ]
})
export class AccountModule { }
