import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  headers: any;

  constructor() {
    let token = localStorage.getItem('token');
    this.headers = {
      "Authorization": `Bearer ${token}`
    };
  }

  async getUserSocialLinks(userName: string): Promise<AxiosResponse<ResponseModel<UserSocialLinksViewModel>>> {
    return await axios.get(`${environment.backendUri}api/user/${userName}/SocialLinks`, { headers: this.headers });
  }
}
