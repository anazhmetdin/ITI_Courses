import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {

  constructor(private _students: StudentsService, private router: Router) {
  }

  createStudent(student:any) {
    console.log(student);
    this._students.addStudent(student).subscribe(res => {
      this.router.navigate(['/']);
    });
  }
}
