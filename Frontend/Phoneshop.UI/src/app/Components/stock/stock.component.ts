import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.scss']
})
export class StockComponent implements OnInit
{
  @Input() stock!: number;
  constructor() { }

  ngOnInit(): void {
  }
}