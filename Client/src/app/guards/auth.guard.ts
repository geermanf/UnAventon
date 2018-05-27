import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { User } from '../models/User';
import { UserService } from '../services/user.service';

@Injectable()
export class AuthGuard implements CanActivate {
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

    // currentUser() {
    //     const user: User = JSON.parse(localStorage.getItem('currentUser'));
    //     return user
    // }

    // currentUser() {
    //     let ret;
    //     this.getUser().subscribe(
    //         data => {
    //             ret = data;
    //             return data;
    //         },
    //         error => {
    //             return error;
    //         });
    //     return ret;
    // }

    getUser() {
        const user: User = JSON.parse(localStorage.getItem('currentUser'));
        return this.userService.getById(user.id).map(
            data => {
                return data;
            },
            error => {
                return error;
            });
    }

    isLogued() {
        if (localStorage.getItem('currentUser')) {
            // logged in so return true
            return true;
        }
        return false;
    }
}
