import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  Id: number = 0;
  student: any;

  constructor(route: ActivatedRoute, private _students: StudentsService) {
    this.Id = +route.snapshot.params["Id"];
  }

  ngOnInit(): void {
    this._students.getStudentById(this.Id).subscribe(
      student => { this.student = student; }
    );
  }
}
