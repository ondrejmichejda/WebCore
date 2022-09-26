import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { UserExampleComponent } from './Components/user-example/user-example.component';
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    UserExampleComponent
  ],
    imports: [
        BrowserModule, HttpClientModule, FormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
