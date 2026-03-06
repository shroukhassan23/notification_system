import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { App } from './app';
import { NotificationsComponent } from './notifications/notifications';
import { AppRoutingModule } from './app.routes';

@NgModule({
  imports: [
    App,
    NotificationsComponent,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [App]
})
export class AppModule { }