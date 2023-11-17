/* eslint-disable @typescript-eslint/no-explicit-any */
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedDetailsService {
  private qrDetails: any;

  private isCustomerSubject = new BehaviorSubject<boolean>(false);
  isCustomer$ = this.isCustomerSubject.asObservable();

  private isQRScannedSubject = new BehaviorSubject<boolean>(false);
  isQRScanned$ = this.isQRScannedSubject.asObservable();

  setCustomerStatus(value: boolean) {
    this.isCustomerSubject.next(value);
  }

  setQRStatus(value: boolean) {
    this.isQRScannedSubject.next(value);
  }



  setQrDetails(details: any) {
    this.qrDetails = details;
  }

  getQrDetails() {
    return this.qrDetails;
  }
}
