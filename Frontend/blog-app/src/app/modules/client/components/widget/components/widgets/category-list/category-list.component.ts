import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category/category.service';
import { CategoryListViewModel } from 'src/app/models/category/category.list.view.model';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
  Categories: Array<CategoryListViewModel>;

  constructor(private categoryService: CategoryService) { }

  async ngOnInit() {
    const categoryResponse = await this.categoryService.getCategories();
    this.Categories = categoryResponse.data.Data;
  }

}
