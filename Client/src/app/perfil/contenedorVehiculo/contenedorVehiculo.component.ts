import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Vehiculo } from '../../models/vehiculo';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { VehiculoService } from '../../services/vehiculo.service';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contenedorvehiculo',
  templateUrl: './contenedorVehiculo.component.html',
  styleUrls: ['./contenedorVehiculo.component.css', '../../../assets/css/modal.css']
})
export class ContenedorVehiculoComponent implements OnInit {
  @Input() vehiculo: any;
  @Output() refresh = new EventEmitter();
  @Output() edit = new EventEmitter();

  constructor(private router: Router,
    private modalService: NgbModal,
    private vehiculoService: VehiculoService,
    private alertService: AlertasService) { }

  ngOnInit() { }

  private refrescarVehiculos(): void {
    this.refresh.emit(null);
  }

  retControlByEdit() {
    this.edit.emit(this.vehiculo);
  }


  abrirBorrarVehiculoModal(BorrarVehiculo) {
    this.modalService.open(BorrarVehiculo);
  }

  borrarVehiculo() {
    this.vehiculoService.delete(this.vehiculo.id)
      .subscribe(
        data => {
          this.alertService.addAlert('success', 'Tus datos se modificaron de manera satisfactoria!');
          this.refrescarVehiculos();
        },
        error => {
          this.alertService.addAlert('danger', 'Lo sentimos, no fue posible modificar tus datos');
        });
  }

}
