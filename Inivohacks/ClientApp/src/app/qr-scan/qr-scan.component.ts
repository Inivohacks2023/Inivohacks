/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxScannerQrcodeComponent } from 'ngx-scanner-qrcode';
import { SharedDetailsService } from '../services/shared-details.service';

@Component({
  selector: 'app-qr-scan',
  templateUrl: './qr-scan.component.html',
  styleUrls: ['./qr-scan.component.css']
})
export class QrScanComponent {

  constructor(private router: Router, private sharedDetailsService: SharedDetailsService) { }
  
  @ViewChild('action') action: NgxScannerQrcodeComponent | undefined;

  isCameraVisible = false;
  hasProcessedQr = false; 
  qrDetails: any; 
  
  scanQR() {
    this.isCameraVisible = !this.isCameraVisible;
    setTimeout(() => {
      if (this.action) {
        this.action.isStart ? this.action.stop() : this.action.start();
      } else {
        console.error('ngx-scanner-qrcode component not available.');
      }
    }, 500);
    if (!this.isCameraVisible && this.action) {
      this.action.stop();
    }
    
  }

  handleQrCodeResult(result: any) {
    if (!this.hasProcessedQr && (result != null || typeof result !== 'undefined')) {
      this.qrDetails = result;
      console.log('QR Code Details:', this.qrDetails);
      this.hasProcessedQr = true; 
      this.isCameraVisible = false;
      if (!this.isCameraVisible && this.action) {
        this.action.stop();
      }
      this.sharedDetailsService.setQRStatus(true);
      this.sharedDetailsService.setQrDetails(JSON.stringify(this.qrDetails));
      this.viewQRDetails();
    }
    this.hasProcessedQr = false;
  }

  viewQRDetails() {
    this.router.navigate(['/qr-details']);
    this.sharedDetailsService.setQRStatus(false);
  }
}
