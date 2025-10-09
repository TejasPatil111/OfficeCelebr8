import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../utils/environment';
import { LoginRequest, LoginResponse } from '../../models/auth/login';
import { RegisterRequest, RegisterResponse } from '../../models/auth/register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `${environment.apiUrl}/Auth`;
  constructor(private http: HttpClient) { }

  login(user : LoginRequest) : Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, user);
  }
  register(user : RegisterRequest) : Observable<RegisterResponse> {
    return this.http.post<RegisterResponse>(`${this.apiUrl}/register`, user);
  }
}
