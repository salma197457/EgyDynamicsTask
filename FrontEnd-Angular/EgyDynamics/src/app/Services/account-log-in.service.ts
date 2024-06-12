import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';


@Injectable({
  providedIn: 'root'
})
export class AccountLogInService {

  r: { id:string} = { id:""};
  constructor(public http:HttpClient, private router: Router, private snackBar: MatSnackBar) 
  { 
    this.CheckToken()
  }

  isAuthenticated=false;
  baseUrl="http://localhost:5013/api/Login";
  
  private CheckToken(): void {
    const token = localStorage.getItem("token");
    if (token) {
      this.isAuthenticated = true;
      this.r = jwtDecode(token);
      console.log(this.r.id);
    } else {
      this.isAuthenticated = false;
    }
  }

  Login(email: string, password: string) {
    const params = new HttpParams().set('email', email).set('password', password);
    
    this.http.get(`${this.baseUrl}?email=${email}&password=${password}`, { params, responseType: 'text' })
    .subscribe(d => {
      this.isAuthenticated = true;
      localStorage.setItem("token", d);
      try {
        this.r = jwtDecode(d);
        console.log(this.r);

        this.router.navigateByUrl("");
      } catch (error) {
        console.error('Failed to decode token:', error);
      }
    },
      (error: HttpErrorResponse) => {
        if (error.status === 401) {
          // Show a snackbar for invalid email or password
          this.snackBar.open('Invalid email or password', 'Close', {
            duration: 5000, // Duration in milliseconds
            verticalPosition: 'top' // Position of the snackbar
          });
        } else if(email == "" && password != ""){
            this.snackBar.open('Email can not be empty', 'Close', {
              duration: 5000, // Duration in milliseconds
              verticalPosition: 'top' // Position of the snackbar
            });
        }
        else if(password == "" && email != ""){
          this.snackBar.open('Password can not be empty', 'Close', {
            duration: 5000, // Duration in milliseconds
            verticalPosition: 'top' // Position of the snackbar
          });
        }
        else{
          this.snackBar.open('Please enter the data', 'Close', {
            duration: 5000, // Duration in milliseconds
            verticalPosition: 'top' // Position of the snackbar
          });
        }
      }
    );
  }
 
  logout(){
    this.isAuthenticated=false;
    localStorage.removeItem("token");
  }
}
