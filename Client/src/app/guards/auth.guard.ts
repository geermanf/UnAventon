import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { User } from '../models/User';
import { UserService } from '../services/user.service';
import { IfObservable } from 'rxjs/observable/IfObservable';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class AuthGuard implements CanActivate {
    public authenticated = new BehaviorSubject(null);
    constructor(private router: Router, private userService: UserService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('currentUser')) {
            // logged in so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['registrarse']);
        return false;
    }

    getUser() {
        if (this.isLogued()) {
            const user: User = JSON.parse(localStorage.getItem('currentUser'));
            return this.userService.getById(user.id).map(
                data => {
                    return data;
                },
                error => {
                    return error;
                })
        }
    }

    getCurrentUserId() {
        return this.getUser().map(data => data.id);
    }

    isLogued() {
        if (localStorage.getItem('currentUser')) {
            // logged in so return true
            return true;
        }
        return false;
    }

    evaluateLogin() {
        this.authenticated.next(this.isLogued());
    }

}
