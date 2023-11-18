import { Component } from '@angular/core';
import { ScanApiService } from '../services/scan-api.service';

@Component({
  selector: 'app-handover-products',
  templateUrl: './handover-products.component.html',
  styleUrls: ['./handover-products.component.css']
})
export class HandoverProductsComponent {

  trackingCode: string = '';
  latitude: string = '';
  longitude: string = '';
  locationName: string = '';

  constructor(private scanApiService: ScanApiService) {


  }

  async transfer() {
    
    var obj = {
      "trackingCode": this.trackingCode,
      "certificateId": 4,
      "latitude": this.latitude,
      "longitude": this.longitude,
      "locationName": this.locationName,
      "userId": 1
    };

    await this.scanApiService.requestTransfer(obj).subscribe(
      async (data:any) => {
        if (data != null) {
          debugger;

          if (confirm("Transfer request made successfully")) {
            window.location.replace("/manufacturer")
          } else {
            window.location.replace("/manufacturer")
          }
          
        }
        else {
          debugger;

        }
      },
      (error:any) => {
        alert(error.error);
      }
    );
    debugger;

  }
}
