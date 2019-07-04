import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { BlogComponent } from './components/blog/blog/blog.component';
import { PageNotFoundComponent } from './components/shared/page-not-found/page-not-found.component';
import { BlogListComponent } from './components/blog/blog-list/blog-list.component';
import { RightWidgetComponent } from './components/shared/right-widget/right-widget.component';
import { CreateBlogFormComponent } from './components/blog/create-blog-form/create-blog-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoryListComponent } from './components/shared/widgets/category-list/category-list.component';
import { BlogDetailComponent } from './components/blog/blog-detail/blog-detail.component';

const appRoutes: Routes = [
  { path: 'blog', component: BlogComponent },
  {
    path: 'blog/create',
    component: CreateBlogFormComponent
  },
  { path: 'blog/:id', component: BlogDetailComponent },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    PageNotFoundComponent,
    BlogComponent,
    BlogListComponent,
    RightWidgetComponent,
    CreateBlogFormComponent,
    CategoryListComponent,
    BlogDetailComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
