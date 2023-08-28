import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/Models/Pagination';
import { IBrands } from '../shared/Models/ProductBrands';
import { ITypes } from '../shared/Models/ProductType';
import { map } from 'rxjs';
 
 
 

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:44370/api/';
  pageSize='40';
  sort='asc';
  search='a';
  constructor( private http:HttpClient) { }

  GetProduct(typeId:number,bradId:Number ){
  let params =new HttpParams();
  if(typeId){
    params=params.append('typeId',typeId.toString());
  }
   if(bradId){
   params= params.append('brandId', bradId.toString());
   }  

   params= params.append('PageSize', this.pageSize );
   params= params.append('sort', this.sort );
   params= params.append('search', this.search);


  
  //?PageSize=40&sort=asc&search=a
  return this.http.get<IPagination>(this.baseUrl + 'Product', {
    observe: 'response', // Use 'response' to get the full response object
    params: params,      // Use the 'params' variable
  }).pipe(
    map(response => {
      return response.body;
    })
  );
  }

  GetBrands() {
    return this.http.get<IBrands[]>(this.baseUrl + 'product/brands');
  }

  GetTypes(){
    return this.http.get<ITypes[]>(this.baseUrl+'product/types')
  }
}
