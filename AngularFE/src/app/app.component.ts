import {Component} from '@angular/core';
import {HttpService} from "./Services/http/http.service";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    public data?: string;

    constructor(http: HttpService) {

        http.get<string>('api/user/one').subscribe({
            next: result => {
                this.data = result
            },
            error: error => console.error(error)
        });
    }

    title = 'AngularFE';
}
