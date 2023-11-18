import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manufacturer-home',
  templateUrl: './manufacturer-home.component.html',
  styleUrls: ['./manufacturer-home.component.css']
})
export class ManufacturerHomeComponent {

  searchTerm: string = '';

  // Dummy data for the table
  medicines = [
    { productId: 1, productName: 'Medicine A', dosage: '10mg', packageType: 'Box' },
    { productId: 2, productName: 'Medicine B', dosage: '5mg', packageType: 'Bottle' },
    { productId: 3, productName: 'Medicine C', dosage: '20mg', packageType: 'Blister' },
    { productId: 4, productName: 'Medicine D', dosage: '15mg', packageType: 'Tube' },
    { productId: 5, productName: 'Medicine E', dosage: '25mg', packageType: 'Packet' }
  ];

  addCertificateLink = '/add-certificate';

  constructor(private router: Router) { }

  filterMedicines() {
    return this.medicines.filter(medicine =>
      medicine.productName.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  navigateToAddProduct() {
    this.router.navigate(['/manufacturer/add-products']);
  }

  navigateToAddPermission(productName: string,dosage:string) {
    this.router.navigate(['/manufacturer/add-permission'], { queryParams: { productName: productName, dosage:dosage } });
  }
}
