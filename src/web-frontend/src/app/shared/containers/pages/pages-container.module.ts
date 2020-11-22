import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampainSliderComponent } from './campain-slider/campain-slider.component';
import { FreeGamesComponent } from './free-games/free-games.component';
import { BannerComponent } from './banner/banner.component';
import { ProductComponent } from './product/product.component';
import { RouterModule } from '@angular/router';
import { HelperComponentsModule } from '../../components/helper/helper-components.module';
import { CarouselModule } from 'ngx-owl-carousel-o';



@NgModule({
  declarations: [CampainSliderComponent, FreeGamesComponent, BannerComponent, ProductComponent],
  imports: [
    CommonModule,
    RouterModule,
    HelperComponentsModule,
  CarouselModule

  ],
  exports: [
    CampainSliderComponent,
    FreeGamesComponent,
     BannerComponent,
      ProductComponent,
  ]
})
export class PagesContainerModule { }
