import { Component, Input, OnInit } from '@angular/core';
import Phone from '../../models/Phone';

@Component({
  selector: 'app-phone-info',
  templateUrl: './phone-info.component.html',
  styleUrls: ['./phone-info.component.scss']
})

export class PhoneInfoComponent implements OnInit
{
  @Input()
  phone!: Phone;

  constructor()
  {
    
  }

  ngOnInit(): void {
  }
}