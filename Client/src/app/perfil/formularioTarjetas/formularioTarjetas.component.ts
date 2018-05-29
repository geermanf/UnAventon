import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';
import { TarjetaService } from '../../services/tarjeta.service';
import { Banco } from '../../models/Banco';
import { TipoTarjeta } from '../../models/TipoTarjeta';
import { BancoService } from '../../services/banco.service';
import { TipoTarjetaService } from '../../services/tipoTarjeta.service';

@Component({
    selector: 'app-formulariotarjetas',
    templateUrl: 'formularioTarjetas.component.html',
    styleUrls: ['../../editar/formsEditar.css', '../../editar/util.css']
})

export class FormularioTarjetasComponent implements OnInit {
    tarjeta: any = {};
    bancos: Banco[] = []
    tiposTarjetas: TipoTarjeta[] = []

    @Output() releaseControl = new EventEmitter();

    constructor(private router: Router,
                private tarjetaService: TarjetaService,
                private bancoService: BancoService,
                private tipoTarjetaService: TipoTarjetaService,
                private alertService: AlertasService) { }

    ngOnInit() {
        this.bancoService.getAll()
        .map( res => Object.keys(res).map(index => this.bancos.push(res[index])))
        .subscribe();

        this.tipoTarjetaService.getAll()
        .map( res => Object.keys(res).map(index => this.tiposTarjetas.push(res[index])))
        .subscribe();
    }

    releaseCtrl() {
        this.releaseControl.emit('cerrar form');
    }

    register() {
        // tslint:disable-next-line:no-debugger
        debugger;
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
