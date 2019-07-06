import { Component, OnInit } from '@angular/core';
import { BlogService } from 'src/app/services/blog/blog.service';
import { BlogDetailViewModel } from 'src/app/models/blog/blog.detail.view.model';
import { ActivatedRoute } from '@angular/router';
import { from } from 'rxjs';

@Component({
  selector: 'app-blog-detail',
  templateUrl: './blog-detail.component.html',
  styleUrls: ['./blog-detail.component.sass']
})
export class BlogDetailComponent implements OnInit {
  blog: BlogDetailViewModel;

  constructor(private blogService: BlogService, private route: ActivatedRoute) { }

  async ngOnInit() {
    const id: number = +this.route.snapshot.paramMap.get('id');
    const blogResponse = await this.blogService.getBlog(id);

    this.blog = blogResponse.data.Data;
  }

}
