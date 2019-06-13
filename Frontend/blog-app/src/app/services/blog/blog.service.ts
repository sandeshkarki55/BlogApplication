import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';
import { BlogListViewModel } from 'src/app/models/blog.list.view.model';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  constructor() { }

  async getBlogs(): Promise<AxiosResponse<ResponseModel<BlogListViewModel[]>>> {
    return await axios.get(`${environment.backendUri}api/blog`);
  }
}
