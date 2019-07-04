import { Component, OnInit } from '@angular/core';
import { BlogCreateViewModel } from 'src/app/models/blog/blog.create.view.model';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BlogService } from 'src/app/services/blog/blog.service';
import { CategoryService } from 'src/app/services/category/category.service';
import { CategoryListViewModel } from 'src/app/models/category/category.list.view.model';

@Component({
  selector: 'app-create-blog-form',
  templateUrl: './create-blog-form.component.html',
  styleUrls: ['./create-blog-form.component.sass']
})
export class CreateBlogFormComponent implements OnInit {
  constructor(private router: Router,
    private blogService: BlogService,
    private categoryService: CategoryService) {
  }

  blogForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    isDraft: new FormControl(true),
    categoryId: new FormControl('', Validators.required)
  });

  model: BlogCreateViewModel = new BlogCreateViewModel();
  categories: Array<CategoryListViewModel>;
  isSubmitted = false;

  async onSubmit() {
    this.isSubmitted = true;
    this.blogForm.controls['isDraft'].setValue(false);
    await this.blogService.saveBlog(this.blogForm.value);
    this.router.navigate(['/', 'blog']);
  }
  async onDraftSave() {
    this.isSubmitted = true;
    this.blogForm.controls['isDraft'].setValue(true);
    await this.blogService.saveBlog(this.blogForm.value);
    this.router.navigate(['/', 'blog']);
  }

  async ngOnInit() {
    const categoryResponse = await this.categoryService.getCategories();
    this.categories = categoryResponse.data.Data;
  }
}
