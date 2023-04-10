import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
name = "";
age = "";

public get ageValid(): boolean {
  return (!!Number.parseInt(this.age) && +this.age >= 18 && +this.age <= 30);
}


public get nameValid() : boolean {
  return this.name.length > 3
}


public get ageNotValid() : boolean {
  return !!this.age && !this.ageValid;
}

public get nameNotValid() : boolean {
  return this.name.length != 0 && !this.nameValid;
}

public get valid() : boolean {
  return this.nameValid && this.ageValid;
}


@Output() addStudent = new EventEmitter();

add() {
  if (this.valid)
  {
    let newStudent = {name:this.name, age:this.age};
    this.name = "";
    this.age = "";

    this.addStudent.emit(newStudent);
  }
}
}
