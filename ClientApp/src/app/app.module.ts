import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HeaderComponent } from './components/header/header.component';
import { TasksComponent } from "./components/tasks/tasks.component";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule } from '@angular/forms';
import { TaskListComponent } from './components/task-list/task-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'fetch-data', component: FetchDataComponent },
        { path: 'header', component: HeaderComponent },
    ]),
    TasksComponent,
    HeaderComponent,
    FontAwesomeModule,
    ReactiveFormsModule
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
