import { Component } from '@angular/core';

@Component({
  selector: 'app-accept-products',
  templateUrl: './accept-products.component.html',
  styleUrls: ['./accept-products.component.css']
})
export class AcceptProductsComponent {

  trackingCode: string = '';
  latitude: string = '';
  longitude: string = '';
  locationName: string = '';

  accept() {

  }
}
