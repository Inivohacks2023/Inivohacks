/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SharedDetailsService } from '../services/shared-details.service'
import domtoimage from 'dom-to-image';

@Component({
  selector: 'app-qr-details',
  templateUrl: './qr-details.component.html',
  styleUrls: ['./qr-details.component.css']
})
export class QrDetailsComponent {
  qrDetails: any;
  name: string = '';
  dosage: string = '';
  manufacturerName: string = '';
  manufacturerAddress: string = '';
  manufacturedDate: string = '';
  expDate: string = '';
  recallStatus: string = '';
  lastAvailablelocation: string = '';
  constructor(private router: Router, private sharedDetailsService: SharedDetailsService,) { }

  ngOnInit(): void {
    this.qrDetails = this.sharedDetailsService.getQrDetails();
    console.log("recieved to details page : " + this.qrDetails);
    this.setValue();
  }

  setValue() {
    this.name = 'Lol';
  }

  backToScan() {
    this.router.navigate(['/qr-scan']);
  }

  saveAsImage() {
    const detailsDiv = document.querySelector('.details') as HTMLElement;
    const h1Element = document.querySelector('h1') as HTMLHeadingElement;

    if (detailsDiv && h1Element) {
      domtoimage.toPng(detailsDiv, {
        width: detailsDiv.offsetWidth,
        height: detailsDiv.offsetHeight,
        style: {
          transform: 'scale(1)',
          transformOrigin: 'top left',
        },
      }).then((dataUrl) => {
        const link = document.createElement('a');
        link.href = dataUrl;
        link.download = 'qr_details.png';
        link.click();
      });
    }
  }
}
