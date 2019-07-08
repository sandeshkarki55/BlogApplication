import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  async getUserSocialLinks(userName: string): Promise<AxiosResponse<ResponseModel<UserSocialLinksViewModel>>> {
    return await axios.get(`${environment.backendUri}api/user/${userName}/SocialLinks`);
  }
}
