import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';
import { TarjetaService } from '../../services/tarjeta.service';

@Component({
    selector: 'app-formulariotarjetas',
    templateUrl: 'formularioTarjetas.component.html',
    styleUrls: ['../../editar/formsEditar.css', '../../editar/util.css']
})

export class FormularioTarjetasComponent implements OnInit {
    tarjeta: any = {};
    hdnValue = 'hidden value'
    @Output() releaseControl = new EventEmitter();

    constructor(private router: Router,
                private tarjetaService: TarjetaService,
                private alertService: AlertasService) { }

    ngOnInit() {
        this.hdnValue = 'hdnvalue'
    }

    releaseCtrl() {
        this.releaseControl.emit('cerrar form');
    }

    register() {
        this.tarjetaService.create(this.tarjeta, 1)
            .subscribe(
                data => {
                    this.alertService.addAlert('success', 'Tus datos se modificaron de manera satisfactoria!');
                    this.releaseCtrl();
                },
                error => {
                    this.alertService.addAlert('danger', 'Lo sentimos, no fue posible modificar tus datos');
                });
    }
}
