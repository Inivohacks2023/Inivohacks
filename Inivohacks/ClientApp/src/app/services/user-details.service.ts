import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserDetailsService {
  private isCustomerSubject = new BehaviorSubject<boolean>(false);
  isCustomer$ = this.isCustomerSubject.asObservable();

  setCustomerStatus(value: boolean) {
    this.isCustomerSubject.next(value);
  }
}
