import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  students: {name:string, age:number}[] = [];

  addStudent(data:{name:string, age:number}) {
    this.students.push(data);
  }
}
