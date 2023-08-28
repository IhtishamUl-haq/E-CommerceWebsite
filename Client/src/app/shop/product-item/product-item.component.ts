import { Component, Input, OnInit } from '@angular/core';
import { IProducts } from 'src/app/shared/Models/Products';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

@Input() product: IProducts | undefined;

ngOnInit(): void {
  
}
}
