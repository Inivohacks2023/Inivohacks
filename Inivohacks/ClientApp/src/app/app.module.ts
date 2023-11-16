import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  NbThemeModule,
  NbLayoutModule,
  NbAccordionModule,
  NbInputModule,
  NbFormFieldModule,
  NbButtonModule,
  NbIconModule,
  NbUserModule
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NgxScannerQrcodeModule } from 'ngx-scanner-qrcode';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { QrScanComponent } from './qr-scan/qr-scan.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    QrScanComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxScannerQrcodeModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent , pathMatch: 'full' },
      { path: 'supplier-scan', component: QrScanComponent },
    ]),
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'default' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbAccordionModule,
    NbFormFieldModule,
    NbIconModule,
    NbInputModule,
    NbButtonModule,
    NbUserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
