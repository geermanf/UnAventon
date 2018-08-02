import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '../../../../node_modules/@angular/router';
import { UserService } from '../../services/user.service';
import { AlertasService } from '../../alertas/alertas.service';
import { NgbModal } from '../../../../node_modules/@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from '../../guards/auth.guard';
import { Pregunta } from '../../models/pregunta';
import { ResponderPreguntaDto } from '../../models/ResponderPreguntaDto';


@Component({
  selector: 'app-contenedorPregunta',
  templateUrl: './contenedorPregunta.component.html',
  styleUrls: ['./contenedorPregunta.component.css', '../../../assets/css/modal.css']
})
export class ContenedorPreguntaComponent implements OnInit {
  @Input() pregunta: Pregunta;
  @Input() mostrarViaje: boolean;
  @Output() refresh = new EventEmitter();
  usuario: any;

  constructor(
    private router: Router,
    private userService: UserService,
    private alertService: AlertasService,
    private modalService: NgbModal,
    private authGuard: AuthGuard) { }

  ngOnInit() {
    this.usuario = this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        return data;
      },
      error => {
        return error;
      });
  }

  private sendRefresh(): void {
    this.refresh.emit('refresh');
  }

  responder() {

    const dto = new ResponderPreguntaDto();

    dto.idPregunta = this.pregunta.id;
    dto.idViaje = this.pregunta.viaje.id;
    dto.respuesta = this.pregunta.respuesta
    this.userService.ResponderPregunta(dto)
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
