import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { AuthGuard } from '../guards/auth.guard';
import { User } from '../models/User';
import { calcularEdad } from './calcularEdad';
import * as moment from 'moment';
import { AlertasService } from '../alertas/alertas.service';

@Component({
    selector: 'app-registrarse',
    templateUrl: './registrarse.component.html',
    styleUrls: ['./registrarse.component.css']
})

export class RegistrarseComponent implements OnInit {
    usuario: any = {};
    passwordRepeat: any;

    constructor(
        private router: Router,
        private userService: UserService,
        private authenticationService: AuthenticationService,
        private alertService: AlertasService,
        public authGuard: AuthGuard) { }

    ngOnInit(): void {
    }
    contraseniasValidas() {
        return (this.usuario.password === this.passwordRepeat);
    }

    esMayorDeEdad() {
        const años = calcularEdad(this.usuario.fechaDeNacimiento);
        return (años >= 18);
    }

    sendNotification() {
        if (!this.esMayorDeEdad()) {
            this.alertService.addAlert('danger', 'Lo sentimos, debes ser mayor de edad para registrarte');
        }
    }

    register() {
        this.usuario.fotoPerfil = '../assets/img/anonym-bw.png';
        this.userService.create(this.usuario)
            .subscribe(
                data => {
                    this.alertService.addAlert('success', 'Bienvenido! Se registró correctamente');
                    this.router.navigate(['/home']);
                },
                error => {
                    this.alertService.addAlert('danger', 'El mail ' + this.usuario.email + 'ya está registrado en el sistema');
                });
    }
}
