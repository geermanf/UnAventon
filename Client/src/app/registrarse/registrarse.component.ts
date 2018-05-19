import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';

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
        private userService: UserService) { }

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
