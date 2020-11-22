import { Component, Input, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { IProduct } from 'src/app/shared/models/product';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-campain-slider',
  templateUrl: './campain-slider.component.html',
  styleUrls: ['./campain-slider.component.scss']
})
export class CampainSliderComponent implements OnInit {
  @Input() title: string;
  @Input() products: IProduct[];
  public newReleases: IProduct[];
  @Input() product: IProduct;
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

  constructor(private apiService: ApiService) {
    this.getNewReleases();
  }
  getNewReleases(): void{
    this.apiService.getNewReleases().subscribe(
      data => {
        this.newReleases = data;
      }
    );
  }

  ngOnInit(): void {
  }

}
