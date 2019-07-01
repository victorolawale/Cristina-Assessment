import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  clickedA = false;
  clickedB = false;

  onEscPressed(){
    this.clickedA = false
    this.clickedB = false
  }
  
  divAClicked(){
    this.clickedA = true
    this.clickedB = false
  }

  divBClicked(){
    this.clickedB = true
    this.clickedA = false
  }

}
