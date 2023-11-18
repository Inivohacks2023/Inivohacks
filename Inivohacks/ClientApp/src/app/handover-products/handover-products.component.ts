import { Component } from '@angular/core';

@Component({
  selector: 'app-handover-products',
  templateUrl: './handover-products.component.html',
  styleUrls: ['./handover-products.component.css']
})
export class HandoverProductsComponent {

  trackingCode: string = '';
  latitude: string = '';
  longitude: string = '';
  locationName: string = '';

  save() {

  }
}
