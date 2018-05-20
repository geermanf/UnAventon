import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { AuthGuard } from '../guards/auth.guard';

@Component({
    selector: 'app-registrarse',
    templateUrl: './registrarse.component.html',
    styleUrls: ['./registrarse.component.css']
})

export class RegistrarseComponent {
    model: any = {};
    passwordRepeat: any;

    constructor(
        private router: Router,
        private userService: UserService,
        private authenticationService: AuthenticationService,
        public authGuard: AuthGuard) { }

        ngOnInit(){
            console.log(this.authGuard.isLogued());
        }

    register() {
        this.userService.create(this.model)
            .subscribe(
                data => {
                    // alert ok
                    this.router.navigate(['']);
                },
                error => {
                    // alert fail
                });
    }
}
