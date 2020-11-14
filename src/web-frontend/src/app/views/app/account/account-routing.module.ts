import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent } from './account.component';
import { CouponsComponent } from './coupons/coupons.component';
import { FavoriteComponent } from './favorite/favorite.component';
import { MyAccountComponent } from './my-account/my-account.component';

const routes: Routes = [
  {
    path: '',
    component: AccountComponent,
    children: [
      { path: '', redirectTo: 'my-account' },
      { path: 'coupons', component: CouponsComponent },
      { path: 'favorite', component: FavoriteComponent },
      { path: 'my-account', component: MyAccountComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
