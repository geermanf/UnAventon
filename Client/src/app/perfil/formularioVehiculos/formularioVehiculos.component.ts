import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { VehiculoService } from '../../services/vehiculo.service';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';
import { AuthGuard } from '../../guards/auth.guard';

@Component({
    selector: 'app-formulariovehiculos',
    templateUrl: 'formularioVehiculos.component.html',
    styleUrls: ['../../editar/formsEditar.css', '../../editar/util.css']
})

export class FormularioVehiculosComponent implements OnInit {
    vehiculo: any = {};
    usuario: any = {};
    @Output() releaseControl = new EventEmitter();
    idUserLogued: number;

    constructor(private router: Router,
                private vehiculoService: VehiculoService,
                private alertService: AlertasService,
                public authGuard: AuthGuard) { }

    ngOnInit() {
        this.authGuard.getCurrentUserId().subscribe(data => this.idUserLogued = data);
        this.getUser();
     }

    releaseCtrl() {
        this.releaseControl.emit('cerrar form');
    }

    getUser() {
        this.usuario = this.authGuard.getUser().subscribe(
            data => {
                this.usuario = data;
                return data;
            },
            error => {
                return error;
            });
    }

    async register() {
        const ret = await this.vehiculoService.ExisteVehiculo(this.vehiculo.patente, this.usuario.id).toPromise();
        if (!ret) {
            if (this.vehiculo.foto === undefined || this.vehiculo.foto === '') {
                this.vehiculo.foto = '../assets/img/vehiculoNoDisponible.png';
            }
            this.vehiculoService.create(this.vehiculo, this.usuario.id)
                .subscribe(
                    data => {
                        this.alertService.addAlert('success', 'Tus datos se modificaron de manera satisfactoria!');
                        this.releaseCtrl();
                    },
                    error => {
                        this.alertService.addAlert('danger',
                            'El vehiculo con patente ' + this.vehiculo.patente + 'ya está registrado en el sistema');
                    });
          } else {
            this.alertService.addAlert('danger', 'Ya tienes registrado este vehiculo');
          }
    }
}
