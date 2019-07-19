import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { SharedModule } from './modules/shared/shared.module';
import { BlogModule } from './modules/blog/blog.module';
import { HomeModule } from './modules/home/home.module';
import { WidgetModule } from './modules/widget/widget.module';

import { routing } from './app.routing';
import { AdminModule } from './modules/admin/admin.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    routing,
    BrowserModule,
    SharedModule,
    BlogModule,
    HomeModule,
    WidgetModule,
    AdminModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
