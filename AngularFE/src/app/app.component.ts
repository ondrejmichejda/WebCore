import {Component} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    public data: UserSelector;

    constructor(http: HttpClient) {

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
