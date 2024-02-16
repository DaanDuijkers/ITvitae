import { Component } from '@angular/core';
import { Router } from '@angular/router'

import Brand from './models/Brand';
import Phone from './models/Phone';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent
{
  opened=false;

  constructor(private router:Router)
  {
    
  }

  goToPage(pageName:string):void
  {
    this.router.navigate([`$(pageName)`]);
  }
}