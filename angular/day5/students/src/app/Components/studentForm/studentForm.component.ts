import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-studentForm',
  templateUrl: './studentForm.component.html',
  styleUrls: ['./studentForm.component.css']
})
export class studentFormComponent {

  @Input() student:any|{} = {};

  ngOnChanges(changes: SimpleChanges): void {
    this.formValidation.patchValue(this.student);
  }

  formValidation = new FormGroup({
    name: new FormControl(this.student["Name"], [Validators.required, Validators.minLength(4)] ),
    age: new FormControl(this.student["Age"], [Validators.required, Validators.min(20), Validators.max(40)] ),
    email: new FormControl(this.student["Email"], [Validators.required, Validators.pattern(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/)] ),
    phone: new FormControl(this.student["Phone"], [Validators.required, Validators.pattern(/^[0-9]{11}$/)] ),
    courses: new FormControl(this.student["Courses"], [Validators.required, Validators.pattern(/^[0-9]+(,[0-9]+)*$/)])
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
  get phoneValid(): boolean {
    return this.formValidation.controls["phone"].valid;
  }
  get coursesValid(): boolean {
    return this.formValidation.controls["courses"].valid;
  }

  @Output() SubmitStudent = new EventEmitter();

  check() {
    if (this.formValidation.valid) {
      console.log(this.formValidation);
      this.SubmitStudent.emit(this.formValidation.value);
    }
  }

}
