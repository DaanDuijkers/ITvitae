import { FormComponent } from './Components/form/form.component';
import { HomeComponent } from './Components/home/home.component';
import { PhoneDetailsComponent } from './Components/phone-details/phone-details.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PhoneListComponent } from './Components/phone-list/phone-list.component';

const routes: Routes = [
  {path:"", component:HomeComponent},
  {path:"phones", component:PhoneListComponent},
  {path:"detail/:id", component:PhoneDetailsComponent},
  {path:"contact", component:FormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }