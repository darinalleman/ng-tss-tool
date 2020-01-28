import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EstimateComponent } from './action-panel/estimate/estimate.component';
import { FormsModule } from '@angular/forms';
import { UploadComponent } from './action-panel/upload/upload.component';
import { HttpClientModule } from '@angular/common/http';
import { ActionPanelComponent } from './action-panel/action-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    EstimateComponent,
    UploadComponent,
    ActionPanelComponent
  ],
  imports: [
    NgbModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
