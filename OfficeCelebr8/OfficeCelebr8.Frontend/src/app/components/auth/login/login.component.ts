import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { LoginRequest, LoginResponse } from '../../../models/auth/login';
import { AuthService } from '../../../services/auth/auth.service';
import { Alert } from '../../../utils/sweetalert/alert';
import { TYPE } from '../../../utils/sweetalert/alertTypes.constants';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterModule, FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginCreds : LoginRequest = new LoginRequest('' ,'');
  errorMsg : string = '';
  constructor(private route : Router, private authService : AuthService) { }

  loginForm = new FormGroup({
    userEmail : new FormControl('', [Validators.required, Validators.email]),
    userPassword : new FormControl('', [Validators.required, Validators.pattern('^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{6,15}$')])
  });
  
  loginUser() {
    if(this.loginForm.invalid) {
      console.log(this.loginForm.value);
      this.loginForm.markAllAsTouched();
      Alert.toast(TYPE.WARNING, true, "Please enter correct email and password");
      return;
    }
    const userEmail = this.loginForm.get('userEmail')?.value;
    const userPswd = this.loginForm.get('userPassword')?.value;
    if(userEmail && userEmail.trim() && userPswd && userPswd.trim()) {
      this.loginCreds.email = userEmail;
      this.loginCreds.password = userPswd;
      this.authService.login(this.loginCreds).subscribe({
        next: (response : LoginResponse) => {
          console.log(response.isLoggedIn);
          sessionStorage.setItem('email', response.email);
          Alert.toast(TYPE.SUCCESS, true, "Logged In Successfully!");
          this.route.navigate(['/']);
        },
        error: (error) => {
          console.error('Login Failed :(', error);
          this.errorMsg = JSON.stringify(error.error.message != null ? error.error.message : error.message);
          Alert.toast(TYPE.ERROR, true, this.errorMsg.replaceAll('"', ''));
        }
      });
    }
  }
  get userEmail() {
    return this.loginForm.get('userEmail');
  }

  get userPassword() {
    return this.loginForm.get('userPassword');
  }
}
