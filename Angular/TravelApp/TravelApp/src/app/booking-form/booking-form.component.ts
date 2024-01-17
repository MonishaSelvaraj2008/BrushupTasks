import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-booking-form',
  templateUrl: './booking-form.component.html',
  styleUrl: './booking-form.component.css'
})
export class BookingFormComponent {
  @Input() mode: string = '';
  roomType: string = '';
  numRooms: string = '';;
  numPersons: string = '';;
  numChildren: string = '';;
  restaurantFacilities: string = '';
}
