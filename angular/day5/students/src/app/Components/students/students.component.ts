import { Component, OnInit } from '@angular/core';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  students: any;

  constructor(private _students: StudentsService) { }

  ngOnInit() {
    this._students.getAllStudents().subscribe(
      data => this.students = data
    );
  }

}
