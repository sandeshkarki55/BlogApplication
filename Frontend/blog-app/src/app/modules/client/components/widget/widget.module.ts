import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RightWidgetComponent } from './components/right-widget/right-widget.component';
import { CategoryListComponent } from './components/widgets/category-list/category-list.component';
import { RouterModule } from '@angular/router';
import { RecentPostsComponent } from './components/widgets/recent-posts/recent-posts.component';
import { FollowUsComponent } from './components/widgets/follow-us/follow-us.component';

@NgModule({
  declarations: [
    RightWidgetComponent,
    CategoryListComponent,
    RecentPostsComponent,
    FollowUsComponent
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
