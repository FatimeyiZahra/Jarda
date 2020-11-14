import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CatalogueComponent } from './catalogue.component';
import { ContactComponent } from './contact/contact.component';
import { HomepageComponent } from './homepage/homepage.component';
import { NewsDetailsComponent } from './news-details/news-details.component';
import { NewsComponent } from './news/news.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsComponent } from './products/products.component';

const routes: Routes = [
  {
    path: '',
    component: CatalogueComponent,
    children: [
      { path: '', component: HomepageComponent },
      { path: 'home', component: HomepageComponent },
      { path: 'contact', component: ContactComponent },
      { path: 'products/:id', component: ProductsComponent },
      { path: 'product/:id', component: ProductDetailsComponent },
      { path: 'newss/:id', component: NewsComponent },
      { path: 'news/:id', component: NewsDetailsComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogueRoutingModule { }
