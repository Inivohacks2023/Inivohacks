import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ScanApiService } from '../app/services/scan-api.service';
import {
  NbThemeModule,
  NbLayoutModule,
  NbAccordionModule,
  NbInputModule,
  NbFormFieldModule,
  NbButtonModule,
  NbIconModule,
  NbUserModule,
  NbTabsetModule,
  NbCardModule,
  NbTreeGridModule,
  NbDatepickerModule,
  NbSelectModule,
  NbToggleModule,
  NbRadioModule
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NgxScannerQrcodeModule } from 'ngx-scanner-qrcode';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { QrScanComponent } from './qr-scan/qr-scan.component';
import { UserMenuComponent } from './user-menu/user-menu.component';
import { HeaderComponent } from './header/header.component';
import { QrDetailsComponent } from './qr-details/qr-details.component';
import { ManufacturerHomeComponent } from './manufacturer-home/manufacturer-home.component';
import { AddProductsComponent } from './add-products/add-products.component';
import { AddPermissionComponent } from './add-permission/add-permission.component';
import { HandoverProductsComponent } from './handover-products/handover-products.component';
import { ManufacturerMenuComponent } from './manufacturer-menu/manufacturer-menu.component';
import { AcceptProductsComponent } from './accept-products/accept-products.component';
import { ProductDetailsUpdateComponent } from './product-details-update/product-details-update.component';
import { RebrandComponent } from './rebrand/rebrand.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    QrScanComponent,
    UserMenuComponent,
    HeaderComponent,
    QrDetailsComponent,
    ManufacturerHomeComponent,
    AddProductsComponent,
    ProductDetailsUpdateComponent,
    AddPermissionComponent,
    HandoverProductsComponent,
    ManufacturerMenuComponent,
    AcceptProductsComponent,
    RebrandComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxScannerQrcodeModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent , pathMatch: 'full' },
      { path: 'qr-scan', component: QrScanComponent },
      { path: 'product-details-update', component: ProductDetailsUpdateComponent },
      { path: 'qr-details', component: QrDetailsComponent },
      { path: 'manufacturer/home', component: ManufacturerHomeComponent },
      { path: 'manufacturer/add-products', component: AddProductsComponent },
      { path: 'manufacturer/add-permission', component: AddPermissionComponent },
      { path: 'manufacturer/handover-products', component: HandoverProductsComponent },
      { path: 'manufacturer', component: ManufacturerMenuComponent },
      { path: 'manufacturer/accept-products', component: AcceptProductsComponent },
      { path: 'manufacturer/rebrand-products', component: RebrandComponent },
    ]),
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'default' }),
    NbDatepickerModule.forRoot(),
    NbLayoutModule,
    NbEvaIconsModule,
    NbAccordionModule,
    NbFormFieldModule,
    NbIconModule,
    NbInputModule,
    NbButtonModule,
    NbUserModule,
    NbTabsetModule,
    NbCardModule,
    NbTreeGridModule,
    NbDatepickerModule,
    NbSelectModule,
    NbToggleModule,
    NbRadioModule,
  ],
  providers: [ScanApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
