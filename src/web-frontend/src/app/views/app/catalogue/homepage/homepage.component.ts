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
  constructor(private apiService: ApiService) {
    this.getFreeGames();
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
}
