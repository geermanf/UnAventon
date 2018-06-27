import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { User } from '../models/User';
import { UserService } from '../services/user.service';
import { IfObservable } from 'rxjs/observable/IfObservable';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable()
export class AuthGuard implements CanActivate {
    public authenticated = new Subject<boolean>();
    authenticated$ = this.authenticated.asObservable();

    constructor(private router: Router, private userService: UserService) { }

    public authenticatedOk() {
        this.authenticated.next(true);
    }

    public authenticatedNotOk() {
        this.authenticated.next(false);
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('currentUser')) {
            // logged in so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/registrarse'], { queryParams: { access: 'notOk' } });
        return false;
    }

    getUser() {
        const user: User = JSON.parse(localStorage.getItem('currentUser'));
        return this.userService.getById(user.id).map(
            data => {
                return data;
            },
            error => {
                return error;
            })
    }

    async userAutorizado(id: number) {
        const cal = await this.userService.TieneCalificacionesPendientes(id).toPromise();
        const cal2 = await this.userService.TienePagosPendientes(id).toPromise()
        debugger;
        return cal && cal2;
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

}
