import {HttpClientModule} from '@angular/common/http';
import {AppComponent} from './app.component';
import {CrudExampleComponent} from './Components/CRUD-Example/crud-example.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from "@angular/forms";
import {BrowserModule} from "@angular/platform-browser";
import {NgModule} from "@angular/core";

@NgModule({
    declarations: [
        AppComponent,
        CrudExampleComponent
    ],
    imports: [
        BrowserModule, HttpClientModule, NgbModule, FormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}
