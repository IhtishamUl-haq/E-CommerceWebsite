import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { IProducts } from '../shared/Models/Products';
import { IPagination } from '../shared/Models/Pagination';
import { IBrands } from '../shared/Models/ProductBrands';
import { ITypes } from '../shared/Models/ProductType';
 

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  
  products:IProducts[]=[];
  productTypes :ITypes[]=[];
  productBrands:IBrands[]=[];
  selectTypeId:number=0;
  selectBrandId:number=0;


  constructor(private shopService:ShopService ) { }

  
  
  ngOnInit(): void {
    this.GetProduct();
      this.GetProducBrands();
      this.GetProductType();
        
       
  }

  GetProduct(){
    this.shopService.GetProduct(this.selectTypeId, this.selectBrandId)
    .subscribe(
      (response: any)  =>{
      this.products=    response.data;
       
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
    this.selectBrandId=bradId;
    this.GetProduct();
    console.log(this.selectBrandId + 'click brands');
  }

  OnSelectTypeId(typeId:number){
   
    this.selectTypeId=typeId;
    this.GetProduct();
     console.log(this.selectTypeId + 'click type');
  }
}