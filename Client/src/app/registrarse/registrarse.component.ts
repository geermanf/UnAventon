import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { AuthGuard } from '../guards/auth.guard';
import { User } from '../models/User';
import { calcularEdad } from './calcularEdad';

@Component({
    selector: 'app-registrarse',
    templateUrl: './registrarse.component.html',
    styleUrls: ['./registrarse.component.css']
})

export class RegistrarseComponent {
    usuario: any = {};
    passwordRepeat: any;

    constructor(
        private router: Router,
        private userService: UserService,
        private authenticationService: AuthenticationService,
        public authGuard: AuthGuard) { }

    ngOnInit() {
    }

    contraseniasValidas() {
        return (this.usuario.password == this.passwordRepeat);
    }

    esMayorDeEdad() {
        let años = calcularEdad(this.usuario.fechaDeNacimiento);
        return (años >= 18);
    }

    register() {
        this.userService.create(this.usuario)
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
