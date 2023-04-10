import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  formValidation = new FormGroup({
    name: new FormControl("", [Validators.required, Validators.minLength(4)] ),
    age: new FormControl("", [Validators.required, Validators.min(20), Validators.max(40)] ),
    email: new FormControl("", [Validators.required, Validators.pattern(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/)] )
  })

  get nameValid(): boolean {
    return this.formValidation.controls["name"].valid;
  }
  get ageValid(): boolean {
    return this.formValidation.controls["age"].valid;
  }
  get emailValid(): boolean {
    return this.formValidation.controls["email"].valid;
  }

  submitted = false;

  check() {
    if (this.nameValid && this.ageValid && this.emailValid) {
      this.submitted = true;
    }
  }

}
