import { Routes, RouterModule } from "@angular/router";
import { BlogComponent } from './modules/client/components/blog/components/blog/blog.component';
import { CreateBlogFormComponent } from './modules/admin/components/create-blog-form/create-blog-form.component';
import { BlogDetailComponent } from './modules/client/components/blog/components/blog-detail/blog-detail.component';
import { ModuleWithProviders, Component } from '@angular/core';
import { ClientLayoutComponent } from './modules/client/components/client-layout/client-layout.component';
import { AdminLayoutComponent } from './modules/admin/components/admin-layout/admin-layout.component';
import { HomeComponent } from './modules/client/components/home/components/home/home.component';
import { PageNotFoundComponent } from './modules/client/components/shared/components/page-not-found/page-not-found.component';
import { LoginComponent } from './modules/admin/components/account/login/login.component';
import { AuthGuardService } from './services/authentication/guard/auth.guard.service';
import { CategoryTableComponent } from './modules/admin/components/category/category-table/category-table.component';

const routes: Routes = [
    {
        path: 'admin/login',
        component: LoginComponent
    },
    {
        path: "admin",
        component: AdminLayoutComponent,
        children: [
            {
                path: 'blog/create',
                component: CreateBlogFormComponent
            },
            {
                path: 'category',
                component: CategoryTableComponent
            }
        ],
        canActivate: [AuthGuardService]
    },
    {
        path: '',
        component: ClientLayoutComponent,
        children: [
            {
                path: 'blog',
                component: BlogComponent
            },
            {
                path: 'blog/:id',
                component: BlogDetailComponent
            },
            {
                path: 'home',
                component: HomeComponent
            },
            {
                path: '',
                redirectTo: '/blog',
                pathMatch: 'full'
            }
        ]
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes)