import { Routes, RouterModule } from "@angular/router";
import { BlogComponent } from './modules/blog/components/blog/blog.component';
import { CreateBlogFormComponent } from './modules/admin/components/create-blog-form/create-blog-form.component';
import { BlogDetailComponent } from './modules/blog/components/blog-detail/blog-detail.component';
import { HomeComponent } from './modules/home/components/home/home.component';
import { PageNotFoundComponent } from './modules/shared/components/page-not-found/page-not-found.component';
import { ModuleWithProviders } from '@angular/core';

const routes: Routes = [
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

export const routing: ModuleWithProviders = RouterModule.forRoot(routes)