import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';
import configurl from '../../assets/config/config.json';
import { AuthenticatedResponse } from './../_interfaces/authenticated-response.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginModel } from '../_interfaces/login.model';

@Component({
  selector: 'login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  invalidLogin?: boolean;
  credentials: LoginModel = { email: '', password: '' };

  url = configurl.apiServer.url + '/api/account/';

  constructor(private router: Router, private http: HttpClient,private jwtHelper : JwtHelperService) { }

  ngOnInit(): void {

  }
  public login = (form: NgForm) => {
    const credentials = JSON.stringify(form.value);
    this.http.post<AuthenticatedResponse>(this.url +"login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe({
      next: (response:  AuthenticatedResponse) => {
      const token = response.token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate([""]);
      },
      error: (err: HttpErrorResponse) => this.invalidLogin = true
    });
  }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
  public logOut = () => {
    localStorage.removeItem("jwt");
  }
  
}
