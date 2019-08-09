import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() {
  }

  public isAuthenticated(): boolean {
    const jwtService = new JwtHelperService();

    var token = localStorage.getItem("token");
    var isTokenExpired = jwtService.isTokenExpired(token);
    return !isTokenExpired;
  }

  public registerToken(token: string): boolean {
    try {
      localStorage.setItem("token", token);
      return true;
    } catch{
      return false;
    }
  }

  public removeToken() {
    localStorage.removeItem("token");
  }
}
