import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TravelApp';
  selectedMode: string = '';

  onModeSelect(mode: string): void {
    this.selectedMode = mode;
  }

}
