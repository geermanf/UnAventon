import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { UserService } from './user.service';
import { AuthGuard } from '../guards/auth.guard';


@Injectable()
export class AuthenticationService {

    constructor(private userService: UserService, private authGuard: AuthGuard) { }

    login(email: string, password: string) {
        return this.userService.executeLogin(email, password)
        .map(
            data => {
                localStorage.setItem('currentUser', JSON.stringify(data));
                this.authGuard.authenticatedOk();
                return data;
            },
            error => {
                return error;
            });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.authGuard.authenticatedNotOk();
    }

}
