import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { IProducts } from '../shared/Models/Products';
import { IPagination } from '../shared/Models/Pagination';
import { IBrands } from '../shared/Models/ProductBrands';
import { ITypes } from '../shared/Models/ProductType';
import { ShopParams } from '../shared/Models/ShopParams';
 

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  
  

  products:IProducts[]=[];
  productTypes :ITypes[]=[];
  productBrands:IBrands[]=[];
  boundaryLinks = true;
  totalCount :number=0;
  shopParams=new ShopParams()


  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'},
  ];

  constructor(private shopService:ShopService ) { }

   
  ngOnInit(): void {
    this.GetProduct();
      this.GetProducBrands();
      this.GetProductType();
        
       
  }

  GetProduct(){
    this.shopService.GetProduct(this.shopParams)
    .subscribe(
        (response: IPagination | null) => {
          if (response !== null) {
      this.products=    response.data;
      this.shopParams.pageNumber=response.pageIndex,
      this.shopParams.pageSize=response.pageSize
      this.totalCount = response.count;
          }
    })
  }
    
  GetProductType(){
   this.shopService.GetTypes().subscribe(
    response=>{
      this.productTypes= [{id: 0,name:'All' } ,...response];
       
       
    }
   )
  }

  GetProducBrands(){
    this.shopService.GetBrands()
      .subscribe(
        response  =>{
         this.productBrands=[{id: 0,name:'All' } ,...response];
         
        //console.log(this.productBrands);
      })
  }
    

  OnSelectBrandId(bradId:number){
    this.shopParams.brandId=bradId;
    this.GetProduct();
    console.log(this.shopParams.brandId + 'click brands');
  }

  OnSelectTypeId(typeId:number){
   
    this.shopParams.typeId=typeId;
    this.GetProduct();
     console.log(this.shopParams.typeId + 'click type');
  }

  OnSortSelected(event: any) {
    this.shopParams.sort = event.target.value; // Use event.target.value to get the selected value
    console.log(this.shopParams.sort); // Make sure the value is correct
    this.GetProduct();
}


  OnPageChanged(event: any) {
    console.log(event);
      this.shopParams.pageNumber = event.page;
      console.log(this.shopParams.pageNumber);
      this.GetProduct();
    
  }
}