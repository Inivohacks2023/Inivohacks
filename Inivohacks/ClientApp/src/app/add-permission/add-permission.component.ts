/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NbDateService } from '@nebular/theme';

@Component({
  selector: 'app-add-permission',
  templateUrl: './add-permission.component.html',
  styleUrls: ['./add-permission.component.css']
})
export class AddPermissionComponent {
  //Dummy Data
  medicines: any[] = [
    { productId: 1, permissions: 'Admin', expDate: '2023-12-31', Certificate: 'ABC123' },
    { productId: 2, permissions: 'User', expDate: '2023-11-30', Certificate: 'XYZ789' },
  ];


  min: Date | undefined;
  selectedDate: Date | undefined;
  isDropdownOpen = false;
  productName: string = '';
  dosage: string = '';
  selectedPermissions: string[] = [];
  permissions = ['View Only', 'Rebrand', 'Update Recall', 'Transfer', 'Accept'];

  constructor(private route: ActivatedRoute, private dateService: NbDateService<Date>) {
    this.min = this.dateService.today();
}


  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.productName = params['productName'];
      this.dosage = params['dosage'];
    });
  }

  onPermissionSelect() {
    console.log('Selected Options:', this.selectedPermissions);
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  toggleSelection(permission: string) {
    const index = this.selectedPermissions.indexOf(permission);

    if (index !== -1) {
      this.selectedPermissions.splice(index, 1);
    } else {
      this.selectedPermissions.push(permission);
    }
  }

  isSelected(permission: string): boolean {
    return this.selectedPermissions.includes(permission);
  }

  save() {
    const selectedOptionsJson = {
      selectedPermissions: this.selectedPermissions,
    };

    const selectedDateJson = {
      selectedDate: this.selectedDate,
    };

    const combinedJson = {
      selectedOptions: selectedOptionsJson,
      selectedDate: selectedDateJson,
    };

    console.log('Combined JSON:', combinedJson);
  }

  onDateChange(event: any): void {
    this.selectedDate = event;
  }

  copyToClipboard(certificate: string): void {
    const textarea = document.createElement('textarea');
    textarea.value = certificate;

    textarea.style.position = 'absolute';
    textarea.style.left = '-9999px';

    document.body.appendChild(textarea);

    textarea.select();
    document.execCommand('copy');

    document.body.removeChild(textarea);
  }

}
