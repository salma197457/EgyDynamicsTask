import { Component } from '@angular/core';
import { AccountLogInService } from '../../Services/account-log-in.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email:string = ""
  password:string = ""

  constructor(public accountService:AccountLogInService,private router:Router){  }

  Login(){
    this.accountService.Login(this.email, this.password);
    this.router.navigateByUrl("/clients")
  }
}
