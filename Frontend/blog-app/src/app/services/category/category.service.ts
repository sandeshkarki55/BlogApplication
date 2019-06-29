import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';
import { CategoryListViewModel } from 'src/app/models/category/category.list.view.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor() { }

  async getCategories(): Promise<AxiosResponse<ResponseModel<CategoryListViewModel[]>>> {
    return await axios.get(`${environment.backendUri}api/category`);
  }
}
