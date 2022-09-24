import {Component} from '@angular/core';
import {HttpService} from "./Services/http/http.service";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    public data: UserSelector;

    constructor(http: HttpService) {

        http.get<UserSelector>('api/user/one').subscribe({
            next: result => {
                this.data = result
            },
            error: error => console.error(error)
        });
    }

    title = 'AngularFE';
}

interface UserSelector {
    id?: number;
}
