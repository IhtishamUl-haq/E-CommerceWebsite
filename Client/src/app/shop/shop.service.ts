import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/Models/Pagination';
import { IBrands } from '../shared/Models/ProductBrands';
import { ITypes } from '../shared/Models/ProductType';
import { map } from 'rxjs';
import { ShopParams } from '../shared/Models/ShopParams';
 
 
 

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:44370/api/';
  //pageSize='40';
  
  search='a';
  constructor( private http:HttpClient) { }

  GetProduct(shopParams:ShopParams ){
  let params =new HttpParams();
  if(shopParams.typeId!==0){
    params=params.append('typeId',shopParams.typeId.toString());
  }
   if(shopParams.brandId!==0){
   params= params.append('brandId', shopParams.brandId.toString());
   }  

 
   params = params.append('pageIndex', shopParams.pageNumber);
   params = params.append('pageSize', shopParams.pageSize);;
   params = params.append('sort', shopParams.sort);
   
    
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
