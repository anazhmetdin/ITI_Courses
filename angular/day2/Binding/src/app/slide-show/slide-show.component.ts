import { Component } from '@angular/core';

@Component({
  selector: 'app-slide-show',
  templateUrl: './slide-show.component.html',
  styleUrls: ['./slide-show.component.css']
})
export class SlideShowComponent {
  img:number = 1
  interval:any
  stop() {
    clearInterval(this.interval)
  }
  play(){
    this.interval = setInterval(() => {
      if (this.img == 5) this.img = 1
      else this.slide(1)
    }, 1000)
  }
  slide(step:number) {
    if (this.img == 5 && step == 1) return
    if (this.img == 1 && step == -1) return

    this.img += step;
  }
}
