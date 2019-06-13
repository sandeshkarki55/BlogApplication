import { Component, OnInit } from '@angular/core';
import { BlogListViewModel } from 'src/app/models/blog.list.view.model';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.sass']
})
export class BlogComponent implements OnInit {
  Blogs: Array<BlogListViewModel>;
  constructor() {
    const blog1: BlogListViewModel = {
      Title: 'Blog 1',
      ShortDescription: 'Hello'
    };

    const blog2: BlogListViewModel = {
      Title: 'Blog 2',
      ShortDescription: 'Hello'
    };
    this.Blogs = [
      blog1, blog2, blog2, blog2, blog2, blog2, blog2, blog2
    ];
  }

  ngOnInit() {
  }

}
