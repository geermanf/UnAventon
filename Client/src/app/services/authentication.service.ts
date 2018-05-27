import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { UserService } from './user.service';

@Injectable()
export class AuthenticationService {
    constructor(private userService: UserService) { }

    login(email: string, password: string) {
        return this.userService.executeLogin(email, password)
        .map(
            data => {
                localStorage.setItem('currentUser', JSON.stringify(data));
                return data;
            },
            error => {
                return error;
            });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}
