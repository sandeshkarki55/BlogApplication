import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from './components/shared/shared.module';
import { BlogModule } from './components/blog/blog.module';
import { HomeModule } from './components/home/home.module';
import { WidgetModule } from './components/widget/widget.module';
import { ClientLayoutComponent } from './components/client-layout/client-layout.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    ClientLayoutComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    SharedModule,
    BlogModule,
    HomeModule,
    WidgetModule
  ]
})
export class ClientModule { }
