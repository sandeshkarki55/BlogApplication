import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RightWidgetComponent } from './components/right-widget/right-widget.component';
import { CategoryListComponent } from './components/widgets/category-list/category-list.component';
import { RouterModule } from '@angular/router';
import { RecentPostsComponent } from './components/widgets/recent-posts/recent-posts.component';

@NgModule({
  declarations: [
    RightWidgetComponent,
    CategoryListComponent,
    RecentPostsComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    RightWidgetComponent
  ]
})
export class WidgetModule { }
