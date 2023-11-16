import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDetailsService } from '../services/user-details.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

    
  constructor(private router: Router, private userDetailsService: UserDetailsService) { }

  ngOnInit(): void {
  }


  isSignUp: boolean = false;

  togglePanel() {
    this.isSignUp = !this.isSignUp;
  }
  loginAsCustomer() {
    this.router.navigate(['/qr-scan']);
    this.userDetailsService.setCustomerStatus(true);
  }
}
