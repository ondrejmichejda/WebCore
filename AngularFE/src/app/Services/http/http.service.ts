import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";

@Injectable({
    providedIn: 'root'
})
export class HttpService {



    constructor(private http: HttpClient) {
    }

    public get<T>(url: string): Observable<T> {
        return this.http.get<T>(environment.apiPrefix + url);
    }
}
