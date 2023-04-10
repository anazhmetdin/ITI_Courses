import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent {
  Id: number;

  constructor(route: ActivatedRoute, private _students: StudentsService, private router: Router) {
    this.Id = +route.snapshot.params["Id"];
  }

  deleteStudent() {

    this._students.deleteStudent(this.Id).subscribe(res => {
      this.backtolist();
    });
  }

  backtolist() {
    this.router.navigate(['/']);
  }
}
