import { Component, Input, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { IProduct } from 'src/app/shared/models/product';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
public productDetails: IProduct;

@Input() title: string;
@Input() product: IProduct;
  // @Input() products: IProduct[];
  constructor(private apiService: ApiService) {
    this.getProductDetails();
   }
   public carouselOptions: OwlOptions = {
    loop: true,
    margin: 30,
    nav: true,
    dots: true,
    autoplay: true,
    autoplayTimeout: 3000,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 1
      },
      1000: {
        items: 1
      },
      1200: {
        items: 1
      },
      1400: {
        items: 1
      }
    }
  };

  ngOnInit(): void {
  }
  getProductDetails(): void{
    this.apiService.getProductDetails(7).subscribe(
      data => {
        this.productDetails = data;
        console.log(data);
      }
    );
  }
}
