import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogComponent } from './components/blog/blog.component';
import { BlogDetailComponent } from './components/blog-detail/blog-detail.component';
import { BlogListComponent } from './components/blog-list/blog-list.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    BlogComponent,
    BlogDetailComponent,
    BlogListComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    BlogComponent,
    BlogDetailComponent
  ]
})
export class BlogModule { }
