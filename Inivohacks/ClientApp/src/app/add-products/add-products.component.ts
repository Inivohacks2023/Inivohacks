import { Component } from '@angular/core';

@Component({
  selector: 'app-add-products',
  templateUrl: './add-products.component.html',
  styleUrls: ['./add-products.component.css']
})
export class AddProductsComponent {
  id: string = '';
  name: string = '';
  dosage: string = '';
  packageType: string = '';

  constructor() { }

  save() {

  }
}
