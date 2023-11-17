import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SharedDetailsService } from '../services/shared-details.service';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css']
})
export class UserMenuComponent {
  isNavigationActive = false;
  isCustomer = false;
  constructor(private router: Router, private sharedDetailsService: SharedDetailsService) { }

  async ngOnInit() {
    await this.sharedDetailsService.isCustomer$.subscribe((value) => {
      this.isCustomer = value;
    });

    await this.changeVisuals();
  }

  toggleNavigation() {
    this.isNavigationActive = !this.isNavigationActive;
  }

  logOut() {
    this.router.navigate(['']);
    this.sharedDetailsService.setCustomerStatus(false);
    this.isCustomer = false;
  }

  changeVisuals() {
    if (this.isCustomer) {
      document.querySelector('.image-box img')?.setAttribute('src', 'https://img.freepik.com/free-vector/isolated-young-handsome-man-set-different-poses-white-background-illustration_632498-649.jpg?w=826&t=st=1700177608~exp=1700178208~hmac=2e12b9a4b9aaaa3c323052d341d40db37fa3e25428832d5a629f5c5e914a7767');
      const usernameElement = document.querySelector('.username');
      usernameElement ? usernameElement.textContent = 'Customer': null;
    } else {
      document.querySelector('.image-box img')?.setAttribute('src', 'https://images.pexels.com/photos/774909/pexels-photo-774909.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1');
    }
  }
}
