import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProducts } from './shared/Models/Products';
import { IPagination } from './shared/Models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
  title="E-commerce"
  

  constructor(){


  }
  
  ngOnInit(): void {
    
  }
  //products: IProducts[] = []; 
  //ngOnInit(): void {
    // this.http.get<IPagination>('https://localhost:44370/api/Product?PageIndex=1&PageSize=20&BrandId=1&TypeId=1&Sort=asc&Search=t')
    //   .subscribe(
    //     (response: IPagination) => {
    //       this.products = response.data;
    //       console.log(response.data);
    //     }
    //   );
 //}
}
