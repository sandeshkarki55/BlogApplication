import { Component, OnInit } from '@angular/core';
import { BlogCreateViewModel } from 'src/app/models/blog.create.view.model';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BlogService } from 'src/app/services/blog/blog.service';

@Component({
  selector: 'app-create-blog-form',
  templateUrl: './create-blog-form.component.html',
  styleUrls: ['./create-blog-form.component.sass']
})
export class CreateBlogFormComponent implements OnInit {
  constructor(router: Router, blogService: BlogService) {
    this.router = router;
    this.blogService = blogService;
  }

  blogForm = new FormGroup({
    title : new FormControl('', Validators.required),
    description : new FormControl('', Validators.required)
  });

  router: Router;
  blogService: BlogService;
  model: BlogCreateViewModel = new BlogCreateViewModel();
  isSubmitted = false;

  async onSubmit() {
    this.isSubmitted = true;
    await this.blogService.saveBlog(this.blogForm.value);
    this.router.navigate(['/', 'blog']);
  }

  ngOnInit() {
  }

}
