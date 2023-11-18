import { Component } from '@angular/core';
import { ScanApiService } from '../services/scan-api.service';

@Component({
  selector: 'app-accept-products',
  templateUrl: './accept-products.component.html',
  styleUrls: ['./accept-products.component.css']
})
export class AcceptProductsComponent {

  trackingCode: string = '';
  latitude: string = '';
  longitude: string = '';
  locationName: string = '';

  constructor(private scanApiService: ScanApiService) {


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
}
