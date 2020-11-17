import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IProduct } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

public getFreeProduct(){
  return this.http.get<IProduct[]>(environment.apiUrl + '/V1/HomePage/free-product')
}

}
