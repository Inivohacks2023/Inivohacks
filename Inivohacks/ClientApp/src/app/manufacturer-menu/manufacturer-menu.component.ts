import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manufacturer-menu',
  templateUrl: './manufacturer-menu.component.html',
  styleUrls: ['./manufacturer-menu.component.css']
})
export class ManufacturerMenuComponent {

  constructor( private router:Router) { }

  navigateToViewProducts() {
    this.router.navigate(['/manufacturer/home']);
  }

  navigateToReadProducts() {
    this.router.navigate(['/manufacturer/home']);
  }
}
