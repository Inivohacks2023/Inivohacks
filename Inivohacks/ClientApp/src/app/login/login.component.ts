import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedDetailsService } from '../services/shared-details.service';
import { ApiServiceService } from '../services/api-service.service';
import { jwtDecode } from "jwt-decode";
import { jwtDecodeModel } from "../models/jwt-decode";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  token: any;
  password='';
  username='';
  isValidUser = false;
  isManufacturer = false;
  isSupplier = false;
  decodedModel: jwtDecodeModel = new jwtDecodeModel();
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
        this.token = localStorage.getItem('token');
        this.isValidUser = true

      }, error => {
        localStorage.removeItem('token');
      })
    if (this.isValidUser) {

      this.decodedModel = jwtDecode(this.token);
      console.log('decodedToken.isManufacturer', this.decodedModel.isManufacturer);
      this.isManufacturer = this.decodedModel.isManufacturer;
      this.isSupplier = this.decodedModel.isSupplier;

      if (this.isSupplier) {
        this.router.navigate(['/product-details-update']);
      }
      //TODO: navigation to supllier or manufacturer
      
      if (this.isManufacturer) {
        this.router.navigate(['/manufacturer']);
      }
    }
  }
}
