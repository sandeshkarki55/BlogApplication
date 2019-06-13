import { Component, OnInit, Input } from '@angular/core';
import { BlogListViewModel } from 'src/app/models/blog.list.view.model';

@Component({
  selector: 'app-blog-list',
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.sass']
})
export class BlogListComponent implements OnInit {

  @Input() blog: BlogListViewModel;
  constructor() { }

  ngOnInit() {
  }

}
