import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
    selector: 'cmp-user-example',
    templateUrl: './user-example.component.html',
    styleUrls: ['./user-example.component.css']
})
export class UserExampleComponent implements OnInit {

    users: User[];
    user: User;
    newUser: string;

    constructor(private http: HttpClient) {
    }

    ngOnInit(): void {
        this.refresh();
    }

    refresh() {
        this.http.get<User[]>('/api/user').subscribe({
            next: res => {this.users = res},
            error: err => console.error(err)
        });

        this.http.get<User>('/api/user/2').subscribe({
            next: res => this.user = res,
            error: err => console.error(err)
        });
    }

    addUser() {
        if(this.newUser.length){
            const body = {Id: null, Name: this.newUser};
            this.http.post('api/user', body).subscribe({
                next: () => this.refresh(),
                error: err => console.error(err)
            });
        }
    }
}

interface User {
    id: number;
    name: string;
}
