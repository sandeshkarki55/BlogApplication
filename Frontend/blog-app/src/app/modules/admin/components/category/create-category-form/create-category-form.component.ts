import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryService } from 'src/app/services/category/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-category-form',
  templateUrl: './create-category-form.component.html',
  styleUrls: ['./create-category-form.component.sass']
})
export class CreateCategoryFormComponent implements OnInit {

  constructor(private categoryService: CategoryService, private router: Router) { }

  categoryForm = new FormGroup({
    name: new FormControl('', Validators.required)
  });

  async onSubmit() {
    this.categoryService.saveCategory(this.categoryForm.value);
    this.router.navigate(['/admin', 'category']);
  }

  ngOnInit() {
  }
}
