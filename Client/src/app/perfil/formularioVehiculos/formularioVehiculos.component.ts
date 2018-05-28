import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { VehiculoService } from '../../services/vehiculo.service';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-formulariovehiculos',
    templateUrl: 'formularioVehiculos.component.html',
    styleUrls: ['../../editar/formsEditar.css', '../../editar/util.css']
})

export class FormularioVehiculosComponent implements OnInit {
    vehiculo: any = {};
    @Output() releaseControl = new EventEmitter();

    constructor(private router: Router,
                private vehiculoService: VehiculoService,
                private alertService: AlertasService) { }

    ngOnInit() { }

    releaseCtrl() {
        this.releaseControl.emit('cerrar form');
    }

    register() {
        if (this.vehiculo.foto === undefined) { this.vehiculo.foto = '../assets/img/anonym-bw.png'; }
        // tslint:disable-next-line:no-debugger
        debugger;
        this.vehiculoService.create(this.vehiculo)
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
