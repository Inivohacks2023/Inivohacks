import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedDetailsService } from '../services/shared-details.service';
import { ApiServiceService } from '../services/api-service.service'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  password='';
  username='';
  isValidUser = false;

  constructor(private router: Router, private sharedDetailsService: SharedDetailsService, private apiService: ApiServiceService) { }

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

  async loginAsSupplierManufacturer() {

    const loginCreds = {
      username: this.username,
      password: this.password
    }
  
    await this.apiService.loginRequest(loginCreds)
      .subscribe(response => {
        console.log('response: ', response);
        localStorage.setItem('token', response.token);
        this.isValidUser = true;
      }, error => {
        localStorage.removeItem('token');
      })
    if (this.isValidUser) {
      //TODO: navigation to supllier or manufacturer
      this.router.navigate(['']);
    }
  }
}
