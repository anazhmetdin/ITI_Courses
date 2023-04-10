import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  Id: number = 0;
  student = {name: "John Doe", email: "john.doe@gmail.com", age: 30};
  constructor(route: ActivatedRoute) {
    this.Id = +route.snapshot.params["Id"];
  }
}
