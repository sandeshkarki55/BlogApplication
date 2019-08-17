import { Injectable } from '@angular/core';
import axios, { AxiosResponse } from 'axios';
import { environment } from 'src/environments/environment';
import { CategoryListViewModel } from 'src/app/models/category/category.list.view.model';
import { promise } from 'protractor';
import { CategoryCreateViewModel } from 'src/app/models/category/category.create.view.model';
import { BaseAxiosService } from '../base-axios-service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseAxiosService {

  constructor() {
    super();
  }

  async getCategories(): Promise<AxiosResponse<ResponseModel<CategoryListViewModel[]>>> {
    return await axios.get(`${environment.backendUri}api/category`);
  }

  async saveCategory(category: CategoryCreateViewModel): Promise<AxiosResponse<ResponseModel<any>>> {
    return await axios.post(`${environment.backendUri}api/category`, category);
  }
  
  async deleteCategory(id: string): Promise<AxiosResponse<any>> {
    return await axios.delete(`${environment.backendUri}api/category/${id}`);
  }
}
