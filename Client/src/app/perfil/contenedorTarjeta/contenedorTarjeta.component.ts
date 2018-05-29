import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Vehiculo } from '../../models/vehiculo';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';
import { TarjetaService } from '../../services/tarjeta.service';

@Component({
  selector: 'app-contenedortarjeta',
  templateUrl: './contenedorTarjeta.component.html',
  styleUrls: ['./contenedorTarjeta.component.css', '../../../assets/css/modal.css']
})
export class ContenedorTarjetaComponent implements OnInit {
  @Input() tarjeta: any;
  @Output() refresh = new EventEmitter();

  constructor(private router: Router,
              private modalService: NgbModal,
              private tarjetaService: TarjetaService,
              private alertService: AlertasService) { }

  ngOnInit() {}

  private refrescarTarjetas(): void {
    this.refresh.emit('refresh');
  }

  abrirBorrarTarjetaModal(BorrarTarjeta) {
    this.modalService.open(BorrarTarjeta);
  }

  TipoTarjetaParaImagen() {
    return this.tarjeta.tipo.descripcion.replace(' ', '').toLowerCase()
  }

  ultimosCuatroNumeros() {
    return this.tarjeta.numeroTarjeta.toString().substr(-4);
  }

  borrarTarjeta() {
    this.tarjetaService.delete(this.tarjeta.id)
    .subscribe(
        data => {
            this.alertService.addAlert('success', 'Tus datos se modificaron de manera satisfactoria!');
            this.refrescarTarjetas();
        },
        error => {
            this.alertService.addAlert('danger', 'Lo sentimos, no fue posible modificar tus datos');
        });
  }

}
