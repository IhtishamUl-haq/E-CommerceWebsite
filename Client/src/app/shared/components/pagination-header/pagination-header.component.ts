import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagination-header',
  templateUrl: './pagination-header.component.html',
  styleUrls: ['./pagination-header.component.css']
})
export class PaginationHeaderComponent {
  @Input() totalCount: number = 0;
  @Input() pageSize: number = 0;
  @Input() pageNumber: number = 0;
}

   

 
