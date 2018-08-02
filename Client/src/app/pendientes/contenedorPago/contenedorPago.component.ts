import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '../../../../node_modules/@angular/router';
import { UserService } from '../../services/user.service';
import { AlertasService } from '../../alertas/alertas.service';
import { Pago } from '../../models/pago';
import { TarjetaService } from '../../services/tarjeta.service';
import { AuthGuard } from '../../guards/auth.guard';
import { PagoDto } from '../../models/pagoDto';

@Component({
  selector: 'app-contenedorPago',
  templateUrl: './contenedorPago.component.html',
  styleUrls: ['./contenedorPago.component.css', '../../../assets/css/modal.css']
})
export class ContenedorPagoComponent implements OnInit {
  @Input() pago: Pago;
  @Output() refresh = new EventEmitter();
  calificacionSeleccionada: any;
  codigoIngresado: any;
  tarjetas: any[] = []
  usuario: any;

  constructor(
    private router: Router,
    private userService: UserService,
    private tarjetaService: TarjetaService,
    private alertService: AlertasService,
    private modalService: NgbModal,
    private authGuard: AuthGuard) { }

  ngOnInit() {
    this.usuario = this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        this.getTarjetas();
        return data;
      },
      error => {
        return error;
      });
  }

  getTarjetas() {
    this.tarjetas = [];
    this.tarjetaService.getByUserId(this.usuario.id)
      .map(res => Object.keys(res).map(index => this.tarjetas.push(res[index])))
      .subscribe();
  }

  ultimosCuatroNumeros(tarjeta) {
    return tarjeta.numeroTarjeta.toString().substr(-4);
  }
  private sendRefresh(): void {
    this.refresh.emit('refresh');
  }

  abrirModalPagar(pagar) {
    this.modalService.open(pagar);
  }

  pagarViaje() {

    const dto = new PagoDto();

    dto.idPago = this.pago.id;
    dto.idTarjeta = this.pago.tarjeta;
    dto.idUser = this.usuario.id;
    this.userService.PagarViaje(dto)
    .subscribe(
      data => {
        this.alertService.addAlert('success', 'El pago se realizó de manera satisfactoria');
        this.sendRefresh();
      },
      error => {
        this.alertService.addAlert('danger', 'Lo sentimos, no fue posible realizar el pago');
      });
  }
}
