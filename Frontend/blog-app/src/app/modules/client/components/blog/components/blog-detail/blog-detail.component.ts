import { Component, OnInit } from '@angular/core';
import { BlogService } from 'src/app/services/blog/blog.service';
import { BlogDetailViewModel } from 'src/app/models/blog/blog.detail.view.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-blog-detail',
  templateUrl: './blog-detail.component.html',
  styleUrls: ['./blog-detail.component.scss']
})
export class BlogDetailComponent implements OnInit {
  blog: BlogDetailViewModel;

  constructor(
    private blogService: BlogService,
    private route: ActivatedRoute) { }

  async ngOnInit() {
    this.route.params.subscribe(async routeParams => {
      const id: number = +routeParams.id;
      const blogResponse = await this.blogService.getBlog(id);

      this.blog = blogResponse.data.Data;
    });
  }

}
