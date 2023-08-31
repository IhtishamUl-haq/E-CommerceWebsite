import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent  {
  
  
  @Input() totalCount:number=0;
  @Input() pageSize:number=0;
  @Output() pageChanged=new EventEmitter<number>();
  
   
   


  OnPagerchanged(event:any){
    this.pageChanged.emit(event);
    console.log("pager"+event)
  }
}
