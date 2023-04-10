import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  Id: number;

  constructor(route: ActivatedRoute, private _students: StudentsService, private router: Router) {
    this.Id = +route.snapshot.params["Id"];
  }

  student:any;

  ngOnInit(): void {
    this._students.getStudentById(this.Id).subscribe(student => {
      this.student = student;
    });
  }

  updateStudent(student:any) {
    student["id"] = this.Id;
    this._students.updateStudent(this.Id, student).subscribe(res => {
      this.router.navigate(['/']);
    });
  }
}
