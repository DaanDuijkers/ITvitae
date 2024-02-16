import { PhoneService } from './../../Services/phone-service/phone-service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Phone from '../../models/Phone';

@Component({
  selector: 'app-phone-details',
  templateUrl: './phone-details.component.html',
  styleUrls: ['./phone-details.component.scss']
})

export class PhoneDetailsComponent implements OnInit
{
  id!: number;
  phone!: Phone;

  constructor(private route: ActivatedRoute, private phoneService: PhoneService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.phoneService.getPhoneById(this.id).subscribe(p => this.phone = p);
    console.log(this.phone);
  }
}