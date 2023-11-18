import { Component } from '@angular/core';

import { ScanApiService } from '../services/scan-api.service';

interface Product {
  value: number,
  display:string
}

@Component({
  selector: 'app-rebrand',
  templateUrl: './rebrand.component.html',
  styleUrls: ['./rebrand.component.css']
})
export class RebrandComponent {
  trackingCode: string = '';
  latitude: string = '';
  longitude: string = '';
  locationName: string = '';
  productList: Product[] = [];
  selectedValue: number = 0;

  constructor(private scanApiService: ScanApiService) {

    this.LoadData();
  }

  async accept() {
    debugger;
    var obj = {
      "trackingCode": this.trackingCode,
      "certificateId": 4,
      "latitude": this.latitude,
      "longitude": this.longitude,
      "locationName": this.locationName,
      "userId": 1
    };

    await this.scanApiService.acceptTransfer(obj).subscribe(
      async (data: any) => {
        if (data != null) {
          ;

          if (confirm("Transfer request accepted successfully.")) {
            window.location.replace("/manufacturer")
          } else {
            window.location.replace("/manufacturer")
          }

        }
        else {
          ;

        }
      },
      (error: any) => {
        alert(error.error);
      }
    );
    ;
  }

  async LoadData() {

    await this.scanApiService.getproducts().subscribe(
      async (data: any) => {
        debugger;
        if (data != null) {
          for (var i = 0; i < data.length; i++) {

            this.productList.push({ value: data[i].productID, display:data[i].name })
          }

        }
        else {
          ;

        }
      },
      (error: any) => {
        debugger;
        alert(error.error);
      }
    );
  }
}
