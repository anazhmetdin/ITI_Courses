import { Component } from '@angular/core';

@Component({
  selector: 'app-bind-box',
  templateUrl: './bind-box.component.html',
  styleUrls: ['./bind-box.component.css']
})
export class BindBoxComponent {
  input:string = "";
  Reset() {
    this.input = "";
    console.log(this.input);
  }
}
