import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-free-games',
  templateUrl: './free-games.component.html',
  styleUrls: ['./free-games.component.scss']
})
export class FreeGamesComponent implements OnInit {
  @Input() title: string;
  @Input() products: IProduct[];
  constructor() { }


  ngOnInit(): void {
  }

}
