import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from '../../services/user.service';
import { PuntuacionDto } from '../../models/puntuacionDto';
import { Router } from '../../../../node_modules/@angular/router';
import { AlertasService } from '../../alertas/alertas.service';


@Component({
  selector: 'app-contenedorPuntuacion',
  templateUrl: './contenedorPuntuacion.component.html',
  styleUrls: ['./contenedorPuntuacion.component.css', '../../../assets/css/modal.css']
})
export class ContenedorPuntuacionComponent implements OnInit {
  @Input() calificacion: any;
  @Output() refresh = new EventEmitter();
  calificacionSeleccionada: any;

  constructor(
    private router: Router,
    private userService: UserService,
    private alertService: AlertasService,
    private modalService: NgbModal) { }

  ngOnInit() {

  }

  private sendRefresh(): void {
    this.refresh.emit('refresh');
  }

  abrirModalPuntuar(puntuar) {
    this.modalService.open(puntuar);
  }

  calificar() {

    const dto = new PuntuacionDto();

    if (this.calificacionSeleccionada === 'Positiva') {
      dto.idPuntuacion = 1;
      dto.Valor = 1;
    } else if (this.calificacionSeleccionada === 'Neutra') {
      dto.idPuntuacion = 2;
      dto.Valor = 0;
    } else if (this.calificacionSeleccionada === 'Negativa') {
      dto.idPuntuacion = 3;
      dto.Valor = -1;
    }

    dto.comentario = this.calificacion.comentario;
    dto.IdPendiente = this.calificacion.id;
    dto.idRol = this.calificacion.rol.id;
    dto.IdUsuarioPuntuador = this.calificacion.usuarioPuntuador.id;
    this.userService.Puntuar(dto, this.calificacion.usuarioCalificado.id)
    .subscribe(
      data => {
        this.alertService.addAlert('success', 'La calificacion fue enviada de manera satisfactoria');
        this.sendRefresh();
      },
      error => {
        this.alertService.addAlert('danger', 'Lo sentimos, no fue posible enviar la calificacion');
      });
  }
}
