import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';
import { AuthGuard } from '../guards/auth.guard';
import { User } from '../models/User';
import { calcularEdad } from './calcularEdad';
import { esUnEmailValido } from './esUnEmailValido';
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
    validado = false;
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private authenticationService: AuthenticationService,
        private alertService: AlertasService,
        public authGuard: AuthGuard) { }

    ngOnInit() {
        const access = this.route.snapshot.queryParams['access'];
        if (access === 'notOk') {
            this.alertService.addAlert('danger', 'Debes estar registrado para acceder a esta funcionalidad. Puedes registrarte aquí');
        }
        
    }

    contraseniasValidas() {
        return ( ((this.usuario.passwordRepeat !== undefined) && (this.usuario.password !== undefined))
                    && (this.usuario.password === this.passwordRepeat));
    }

    formatoContraseniaValido() {
        return ( (this.usuario.password !== undefined) && (this.usuario.password.length >= 6));
    }

    esMayorDeEdad() {
        if (this.usuario.fechaDeNacimiento !== undefined) {
            const años = calcularEdad(this.usuario.fechaDeNacimiento);
            console.log(años);
            return (años >= 18);
        }
    }

    esUnEmail() {
        if (this.usuario.email !== undefined) {
             return (esUnEmailValido(this.usuario.email));
        }
    }

    sendNotification() {
        this.validado = true;
        console.log(this.esMayorDeEdad());
        if (!this.esMayorDeEdad() && this.usuario.fechaDeNacimiento !== undefined) {
            this.alertService.addAlert('danger', 'Lo sentimos, debes ser mayor de edad para registrarte');
        }
        if (!this.esUnEmail() && this.usuario.email !== undefined) {
            this.alertService.addAlert('danger', 'El mail ingresado no es valido, por favor, prueba de nuevo');
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
