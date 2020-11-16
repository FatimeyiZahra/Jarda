import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutContainerModule } from 'src/app/shared/containers/layout/layout-container.module';


@NgModule({
  declarations: [AppComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    LayoutContainerModule
  
  ]
})
export class AppModule { }
