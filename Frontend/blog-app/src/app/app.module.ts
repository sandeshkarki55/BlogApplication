import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { BlogComponent } from './components/blog/blog.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { BlogListComponent } from './components/blog-list/blog-list.component';
import { RightWidgetComponent } from './components/right-widget/right-widget.component';
import { CreateBlogFormComponent } from './components/create-blog-form/create-blog-form.component';
import { BlogCreateViewModel } from './models/blog.create.view.model';
import { ReactiveFormsModule } from '@angular/forms';

const appRoutes: Routes = [
  { path: 'blog', component: BlogComponent },
  // { path: 'hero/:id',      component: HeroDetailComponent },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'blog/create',
    component: CreateBlogFormComponent
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
    CreateBlogFormComponent
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
