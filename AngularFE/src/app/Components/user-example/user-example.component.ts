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
        this.getAll();
    }

    getAll() {
        this.users = [];
        this.http.get<User[]>('/api/user').subscribe({
            next: res => {this.users = res},
            error: err => console.error(err)
        });
    }

    getOne(id: string): void{
        this.http.get<User>('/api/user/' + id).subscribe({
            next: res => this.user = res,
            error: err => this.user = {id: 0, name: 'nenaslo me'}
        });
    }

    addUser() {
        if(this.newUser.length){
            const body = {Id: null, Name: this.newUser};
            this.http.post('api/user', body).subscribe({
                next: res => {
                    // console.log(res);
                    this.getAll();
                },
                error: err => console.error(err)
            });
        }
    }

    edit(user: User) {
        this.http.put('/api/user/'+user.id, user).subscribe({
            next: () => this.getAll()
        });
    }

    delete(user: User) {
        this.http.delete('/api/user/'+user.id).subscribe({
            next: () => this.getAll()
        });
    }
}

interface User {
    id: number;
    name: string;
}
