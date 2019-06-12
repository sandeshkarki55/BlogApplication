import { Component, OnInit } from '@angular/core';
import { BlogListModel } from 'src/app/models/blog.list.model';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.sass']
})
export class BlogComponent implements OnInit {
  Blogs: Array<BlogListModel>;
  constructor() {
    const blog1: BlogListModel = {
      Title: 'Blog 1',
      ShortDescription: 'Hello'
    };

    const blog2: BlogListModel = {
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
