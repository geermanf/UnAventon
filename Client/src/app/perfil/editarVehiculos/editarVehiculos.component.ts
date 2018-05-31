import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { VehiculoService } from '../../services/vehiculo.service';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';
import { AuthGuard } from '../../guards/auth.guard';

@Component({
    selector: 'app-editarvehiculos',
    templateUrl: 'editarVehiculos.component.html',
    styleUrls: ['../../editar/formsEditar.css', '../../editar/util.css']
})

export class EditarVehiculosComponent implements OnInit {
    @Input() vehiculo: any;
    bkpVehiculo: any;
    usuario: any = {};
    @Output() event = new EventEmitter();
    idUserLogued: number;
    urlERROR = '../assets/img/vehiculoNoDisponible.png';

    constructor(private router: Router,
                private vehiculoService: VehiculoService,
                private alertService: AlertasService,
                public authGuard: AuthGuard) { }

    ngOnInit() {
        this.authGuard.getCurrentUserId().subscribe(data => this.idUserLogued = data);
        this.getUser();
        this.bkpVehiculo = Object.assign({}, this.vehiculo);
     }

    releaseCtrl() {
        this.event.emit('cerrar');
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

    errorUrl() {
        return this.urlERROR;
    }

    register() {
        if (this.bkpVehiculo.foto === undefined || this.bkpVehiculo.foto === '') {
            this.bkpVehiculo.foto = '../assets/img/vehiculoNoDisponible.png';
        }
        this.vehiculoService.update(this.bkpVehiculo)
            .subscribe(
                data => {
                    this.alertService.addAlert('success', 'Tus datos se modificaron de manera satisfactoria!');
                    this.releaseCtrl();
                },
                error => {
                    this.alertService.addAlert('danger',
                        'El vehiculo con patente ' + this.vehiculo.patente + 'ya está registrado en el sistema');
                });
    }
}
