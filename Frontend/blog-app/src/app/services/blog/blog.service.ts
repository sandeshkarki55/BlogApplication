import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';
import { BlogListViewModel } from 'src/app/models/blog.list.view.model';
import { BlogCreateViewModel } from 'src/app/models/blog.create.view.model';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  constructor() { }

  async getBlogs(): Promise<AxiosResponse<ResponseModel<BlogListViewModel[]>>> {
    return await axios.get(`${environment.backendUri}api/blog`);
  }
  async saveBlog(blog: BlogCreateViewModel): Promise<AxiosResponse<ResponseModel<any>>> {
    return await axios.post(`${environment.backendUri}api/blog`, blog);
  }
}
