import { Component, OnInit } from '@angular/core';
import { BlogListViewModel } from 'src/app/models/blog/blog.list.view.model';
import { BlogService } from 'src/app/services/blog/blog.service';
@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.sass']
})
export class BlogComponent implements OnInit {
  Blogs: Array<BlogListViewModel>;
  constructor(private blogService: BlogService) {
  }

  async ngOnInit() {
    const blogResponse = await this.blogService.getBlogs();

    this.Blogs = blogResponse.data.Data;
  }
}
