import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { CopyrightComponent } from './copyright/copyright.component';
import { MenuComponent } from './menu/menu.component';



@NgModule({
  declarations: [HeaderComponent, FooterComponent, CopyrightComponent, MenuComponent],
  imports: [
    CommonModule
  ],
  exports: [
    HeaderComponent, 
    FooterComponent, 
    CopyrightComponent, 
    MenuComponent
  ]
})
export class LayoutContainerModule { }
