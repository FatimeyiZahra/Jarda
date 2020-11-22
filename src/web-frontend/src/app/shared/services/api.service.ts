import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IProduct } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

public getFreeProduct() {
  return this.http.get<IProduct[]>(environment.apiUrl + '/V1/HomePage/free-product');
}
public getNewReleases() {
  return this.http.get<IProduct[]>(environment.apiUrl + '/V1/HomePage/new-product');
}
public getCoomingProduct() {
  return this.http.get<IProduct[]>(environment.apiUrl + '/V1/HomePage/coming-product');
}

public getProductDetails(id: number){
  return this.http.get<IProduct>(environment.apiUrl + '/V1/HomePage/product/' + id);

}

}
