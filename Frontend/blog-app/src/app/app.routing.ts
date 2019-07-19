import { Routes, RouterModule } from "@angular/router";
import { BlogComponent } from './modules/client/components/blog/components/blog/blog.component';
import { CreateBlogFormComponent } from './modules/admin/components/create-blog-form/create-blog-form.component';
import { BlogDetailComponent } from './modules/client/components/blog/components/blog-detail/blog-detail.component';
import { ModuleWithProviders, Component } from '@angular/core';
import { ClientLayoutComponent } from './modules/client/components/client-layout/client-layout.component';
import { AdminLayoutComponent } from './modules/admin/components/admin-layout/admin-layout.component';
import { HomeComponent } from './modules/client/components/home/components/home/home.component';
import { PageNotFoundComponent } from './modules/client/components/shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
    {
        path: 'blog',
        component: ClientLayoutComponent,
        children: [
            {
                path: '',
                component: BlogComponent
            },
            {
                path: ':id',
                component: BlogDetailComponent
            }
        ]
    },
    {
        path: 'home',
        component: ClientLayoutComponent,
        children: [
            {
                path: '',
                component: HomeComponent
            }
        ]
    },
    {
        path: "admin",
        component: AdminLayoutComponent,
        children: [
            {
                path: 'blog/create',
                component: CreateBlogFormComponent
            }
        ]
    },
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