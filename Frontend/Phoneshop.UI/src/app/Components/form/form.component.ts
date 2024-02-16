import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})

export class FormComponent
{
  formMain: FormGroup;
  submitMsg?: string;

  constructor(private formBuilder: FormBuilder) {
    this.formMain = this.formBuilder.group({
      name: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      message: new FormControl('', [Validators.required])
    });
  }

  submitForm(): void
  {
    this.submitMsg = `name: ${this.formMain.get("name")?.value}; email: ${this.formMain.get("email")?.value}; message: ${this.formMain.get("message")?.value};`;
    
    console.log(this.submitMsg);
  }
}