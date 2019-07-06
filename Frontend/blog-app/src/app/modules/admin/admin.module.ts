import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateBlogFormComponent } from './components/create-blog-form/create-blog-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    CreateBlogFormComponent
  ],
  exports: [
    CreateBlogFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class AdminModule {
}
