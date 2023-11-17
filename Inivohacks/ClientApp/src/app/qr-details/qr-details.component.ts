/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SharedDetailsService } from '../services/shared-details.service';

@Component({
  selector: 'app-qr-details',
  templateUrl: './qr-details.component.html',
  styleUrls: ['./qr-details.component.css']
})
export class QrDetailsComponent {
  qrDetails: any;
  constructor(private router: Router, private sharedDetailsService: SharedDetailsService,) { }

  ngOnInit(): void {
    this.qrDetails = this.sharedDetailsService.getQrDetails();
    console.log("recieved to details page : " + this.qrDetails);
  }
}
