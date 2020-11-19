import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {
 public freeGames: IProduct[];
 public newReleases: IProduct[];
 public coomingProduct: IProduct[];
  constructor(private apiService: ApiService) {
    this.getFreeGames();
    this.getNewReleases();
    this.getCoomingProduct();
  }

  ngOnInit(): void {
  }

  getFreeGames(): void{
    this.apiService.getFreeProduct().subscribe(
      data => {
        this.freeGames = data;
      }
    );
  }
  getNewReleases(): void{
    this.apiService.getNewReleases().subscribe(
      data => {
        this.newReleases = data;
      }
    );
  }
  getCoomingProduct(): void{
    this.apiService.getCoomingProduct().subscribe(
      data => {
        this.coomingProduct = data;
      }
    );
  }
}
