import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CatalogueRoutingModule } from './catalogue-routing.module';
import { CatalogueComponent } from './catalogue.component';
import { HomepageComponent } from './homepage/homepage.component';
import { ProductsComponent } from './products/products.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { NewsComponent } from './news/news.component';
import { NewsDetailsComponent } from './news-details/news-details.component';
import { ContactComponent } from './contact/contact.component';
import { PagesContainerModule } from 'src/app/shared/containers/pages/pages-container.module';
import { HelperComponentsModule } from 'src/app/shared/components/helper/helper-components.module';
import { CarouselModule } from 'ngx-owl-carousel-o';


@NgModule({
  declarations: [CatalogueComponent, HomepageComponent, ProductsComponent, ProductDetailsComponent, NewsComponent, NewsDetailsComponent, ContactComponent],
  imports: [
    CommonModule,
    CatalogueRoutingModule,
    PagesContainerModule,
    CarouselModule,
  ]
})
export class CatalogueModule { }
