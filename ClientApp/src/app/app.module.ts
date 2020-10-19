import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EstimateComponent } from './action-panel/modify/estimate/estimate.component';
import { FormsModule } from '@angular/forms';
import { UploadComponent } from './action-panel/upload/upload.component';
import { HttpClientModule } from '@angular/common/http';
import { ActionPanelComponent } from './action-panel/action-panel.component';
import { ModifyComponent } from './action-panel/modify/modify.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { HasFtpComponent } from './action-panel/modify/has-ftp/has-ftp.component';
import { HasPowerComponent } from './action-panel/modify/has-power/has-power.component';

@NgModule({
  declarations: [
    AppComponent,
    EstimateComponent,
    UploadComponent,
    ActionPanelComponent,
    ModifyComponent,
    HasFtpComponent,
    HasPowerComponent
  ],
  imports: [
    NgbModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
