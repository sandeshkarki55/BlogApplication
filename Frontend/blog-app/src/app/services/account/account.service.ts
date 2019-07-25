import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';
import { LoginViewModel } from 'src/app/models/account/login.view.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor() { }

  async loginAsync(loginViewModel: LoginViewModel): Promise<AxiosResponse<string>> {
    return await axios.post(`${environment.backendUri}api/account/login`, loginViewModel);
  }
}
