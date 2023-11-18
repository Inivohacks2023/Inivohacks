import { Component } from '@angular/core';

@Component({
  selector: 'app-product-details-update',
  templateUrl: './product-details-update.component.html',
  styleUrls: ['./product-details-update.component.css']
})
export class ProductDetailsUpdateComponent {

  options = [
    { value: 'GTIN', label: 'GTIN' },
    { value: 'SAFEMED', label: 'SAFEMED' },
  ];
  option: any;

  trackId: any;
  token: any;
  productName: any;
  recallStatus: any;
  status: any;
  notes: any;
  noOfProducts: any;
  batchID: any;

}
