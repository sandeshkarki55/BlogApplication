import { Component, OnInit, Input } from '@angular/core';
import { BlogListModel } from 'src/app/models/blog.list.model';

@Component({
  selector: 'app-blog-list',
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.sass']
})
export class BlogListComponent implements OnInit {

  @Input() blog: BlogListModel;
  constructor() { }

  ngOnInit() {
  }

}
