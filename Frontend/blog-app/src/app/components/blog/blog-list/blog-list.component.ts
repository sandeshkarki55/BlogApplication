import { Component, OnInit, Input } from '@angular/core';
import { BlogListViewModel } from 'src/app/models/blog/blog.list.view.model';

@Component({
  selector: 'app-blog-list',
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.scss']
})
export class BlogListComponent implements OnInit {

  @Input() blog: BlogListViewModel;
  constructor() { }

  ngOnInit() {
  }

}
