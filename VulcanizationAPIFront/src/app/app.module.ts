import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from './guards/auth-guard.service';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginComponent } from './login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VulcanizationsListComponent } from './components/vulcanizations/vulcanizations-list/vulcanizations-list.component';
import { ServicesListComponent } from './components/services/services-list/services-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';

//all components routes
const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'vulcanizations', component: VulcanizationsListComponent },
  { path: 'services', component: ServicesListComponent }
];

//function is use to get jwt token from local storage
export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    LoginComponent,
    VulcanizationsListComponent,
    ServicesListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7299", "https://localhost:7264/", "localhost:7264"],
        disallowedRoutes: []
      }}),
    NgbModule,
    BrowserAnimationsModule,
    MatDialogModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent],
  entryComponents: [ServicesListComponent]
})
export class AppModule { }
