import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { RegisterRequest, RegisterResponse } from '../../../models/auth/register';
import { AuthService } from '../../../services/auth/auth.service';
import { Alert } from '../../../utils/sweetalert/alert';
import { TYPE } from '../../../utils/sweetalert/alertTypes.constants';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerCreds : RegisterRequest = new RegisterRequest(0, '', '', '' ,'');
  errorMsg : string = '';
  constructor(private route : Router, private authService : AuthService) { }
  
  registerForm = new FormGroup({
    employeeID : new FormControl('', [Validators.required]),
    userName : new FormControl('', [Validators.required]),
    designation : new FormControl('', [Validators.required]),
    userEmail : new FormControl('', [Validators.required, Validators.email]),
    userPassword : new FormControl('', [Validators.required, Validators.pattern('^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{6,15}$')])
  });

  registerUser() {
    if(this.registerForm.invalid) {
      console.log(this.registerForm.value);
      this.registerForm.markAllAsTouched();
      Alert.toast(TYPE.WARNING, true, "Please enter correct email and password");
      return;
    }
    const userEmpID = this.registerForm.get('employeeID')?.value;
    const userName = this.registerForm.get('userName')?.value;
    const userDesignation = this.registerForm.get('designation')?.value;
    const userEmail = this.registerForm.get('userEmail')?.value;
    const userPswd = this.registerForm.get('userPassword')?.value;
    if(userEmpID && Number(userEmpID) && userName && userName.trim() &&
       userDesignation && userDesignation && userEmail && userEmail.trim() &&
       userPswd && userPswd.trim()) {
        this.registerCreds.employeeId = Number(userEmpID);
        this.registerCreds.name = userName;
        this.registerCreds.designation = userDesignation;
        this.registerCreds.email = userEmail;
        this.registerCreds.password = userPswd;
        this.authService.register(this.registerCreds).subscribe({
          next: (response : RegisterResponse) => {
            console.log(response);
            Alert.toast(TYPE.SUCCESS, true, "Registered Successfully! Please log in.");
            this.route.navigate(['/login']);
          },
          error: (error) => {
            console.error('Registration Failed :(', error);
            this.errorMsg = JSON.stringify(error.error.message != null ? error.error.message : error.message);
            Alert.toast(TYPE.ERROR, true, this.errorMsg.replaceAll('"', ''));
          }
        });
    }
  }
  
  get employeeID() {
    return this.registerForm.get('employeeID');
  }
  get userDesignation() {
    return this.registerForm.get('designation');
  }
  get userName() {
    return this.registerForm.get('userName');
  }
  get userEmail() {
    return this.registerForm.get('userEmail');
  }
  get userPassword() {
    return this.registerForm.get('userPassword');
  }
}
