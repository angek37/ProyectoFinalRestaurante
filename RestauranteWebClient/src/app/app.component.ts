import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  items = [
    {
      title: 'Respuestas',
      link: 'respuestas',
    }
  ];

  Constructor() {

  }

  goHome() {

  }
}
