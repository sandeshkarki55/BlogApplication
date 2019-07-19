import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateBlogFormComponent } from './components/create-blog-form/create-blog-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CKEditorModule } from 'ckeditor4-angular';
import { CreateUserComponent } from './components/user/create-user/create-user.component';
import { UserListComponent } from './components/user/user-list/user-list.component';
import { AdminLayoutComponent } from './components/admin-layout/admin-layout.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    CreateBlogFormComponent,
    CreateUserComponent,
    UserListComponent,
    AdminLayoutComponent
  ],
  exports: [
    CreateBlogFormComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    CKEditorModule
  ]
})
export class AdminModule {
}
