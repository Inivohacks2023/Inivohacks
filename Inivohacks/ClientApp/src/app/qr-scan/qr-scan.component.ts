/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, ViewChild } from '@angular/core';
import { NgxScannerQrcodeComponent } from 'ngx-scanner-qrcode';

@Component({
  selector: 'app-qr-scan',
  templateUrl: './qr-scan.component.html',
  styleUrls: ['./qr-scan.component.css']
})
export class QrScanComponent {
  
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
    if (!this.hasProcessedQr) {
      this.qrDetails = result; // Store QR code details
      console.log('QR Code Details:', this.qrDetails);
      this.hasProcessedQr = true; // Set the flag to true to prevent further processing
      this.isCameraVisible = false; // Hide the camera view
      if (!this.isCameraVisible && this.action) {
        this.action.stop();
      }
    }
    this.hasProcessedQr = false;
  }
}
