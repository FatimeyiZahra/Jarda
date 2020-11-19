import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
@Input() title: string;
@Input() product: IProduct;
  // @Input() title: string;
  // @Input() products: IProduct[];
  constructor() { }

  ngOnInit(): void {
  }

}
