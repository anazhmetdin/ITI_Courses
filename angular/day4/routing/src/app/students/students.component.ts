import { Component } from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent {
students: {name:string, age:number, email:string}[] = [
  {name: "John Doe", age: 32, email: "johndoe@example.com"},
  {name: "Vince negatives", age: 22, email: "vincenegates@example.com"},
  {name: "Mary Poppins", age: 29, email: "mariopoppins@example.com"},
  {name: "Susan Smith", age: 35, email: "susansmith@example.com"},
  {name: "Adam Smith", age: 29, email: "adamsmith@example.com"},
  {name: "Claire Smith", age: 20, email: "clairesmith@example.com"},
  {name: "David Smith", age: 27, email: "davsmith@example.com"},
  {name: "Rich Smith", age: 32, email: "ricsmith@example.com"},
  {name: "Nathan Smith", age: 39, email: "nathsmith@example.com"},
  {name: "Richard Smith", age: 47, email: "richsmith@example.com"},
  {name: "Ringo Star", age: 27, email: "ringo@example.com"},
  {name: "Moses Ma", age: 36, email: "moses@example.com"}
]
}
