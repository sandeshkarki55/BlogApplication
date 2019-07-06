import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';
import { BlogListViewModel } from 'src/app/models/blog/blog.list.view.model';
import { BlogCreateViewModel } from 'src/app/models/blog/blog.create.view.model';
import { BlogDetailViewModel } from 'src/app/models/blog/blog.detail.view.model';
import { RecentBlogViewModel } from 'src/app/models/blog/recent.blog.view.model';

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

  async getBlog(id: number): Promise<AxiosResponse<ResponseModel<BlogDetailViewModel>>> {
    return await axios.get(`${environment.backendUri}api/blog/${id}`);
  }

  async getRecentBlogs(): Promise<AxiosResponse<ResponseModel<RecentBlogViewModel[]>>> {
    return await axios.get(`${environment.backendUri}api/blog/Recent`);
  }
}
