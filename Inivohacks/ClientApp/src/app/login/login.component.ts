import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedDetailsService } from '../services/shared-details.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

    
  constructor(private router: Router, private sharedDetailsService: SharedDetailsService) { }

  ngOnInit(): void {
  }


  isSignUp: boolean = false;

  togglePanel() {
    this.isSignUp = !this.isSignUp;
  }
  loginAsCustomer() {
    this.router.navigate(['/qr-scan']);
    this.sharedDetailsService.setCustomerStatus(true);
  }
}
