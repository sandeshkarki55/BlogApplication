import { Component, OnInit } from '@angular/core';
import { BlogService } from 'src/app/services/blog/blog.service';

@Component({
  selector: 'app-recent-posts',
  templateUrl: './recent-posts.component.html',
  styleUrls: ['./recent-posts.component.scss']
})
export class RecentPostsComponent implements OnInit {

  constructor(private blogService: BlogService) { }

  recentBlogs: Array<any>;

  async ngOnInit() {
    const recentPosts = await this.blogService.getRecentBlogs();
    this.recentBlogs = recentPosts.data.Data;
  }

}
