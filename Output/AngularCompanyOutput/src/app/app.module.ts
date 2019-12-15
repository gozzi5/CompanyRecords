import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatRippleModule } from '@angular/material/core';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule  } from '@angular/forms';
import { CompanyService } from './services/company.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { HttpClientModule } from '@angular/common/http';
import { CompanyComponent } from './company/company.component';
import { HomeComponent } from './home/home.component'
@NgModule({
  declarations: [
        AppComponent,
        CompanyComponent,
        HomeComponent,
        
        
  ],
    imports: [
        
    BrowserModule,
    AppRoutingModule,
      BrowserAnimationsModule,
      MatRippleModule,
       FormsModule,
       
      MatProgressBarModule,
        MatButtonModule,
        MatSnackBarModule,
      MatInputModule,
      MatCardModule,
      MatToolbarModule,
      HttpClientModule,

  ],
    providers: [CompanyService, { provide: 'BASE_URL', useFactory: getBaseUrl }],
    bootstrap: [AppComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
export function getBaseUrl() {
    return environment.baseUrl;
}
