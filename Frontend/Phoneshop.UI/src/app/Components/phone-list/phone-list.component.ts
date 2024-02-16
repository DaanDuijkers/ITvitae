import { PhoneService } from './../../Services/phone-service/phone-service';
import { Component, Input, OnInit } from '@angular/core';
import Phone from '../../models/Phone';

@Component({
  selector: 'app-phone-list',
  templateUrl: './phone-list.component.html',
  styleUrls: ['./phone-list.component.scss'],

  template: '<h2>test</h2>'
})

export class PhoneListComponent implements OnInit
{
  phones: Phone[] = [];

  constructor(private phoneService: PhoneService)  { }

  ngOnInit(): void {
    this.phoneService.getPhones().subscribe(p => this.phones = p);
  }
}