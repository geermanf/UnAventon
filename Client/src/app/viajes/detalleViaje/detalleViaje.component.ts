import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ViajeService } from '../../services/viaje.service';
import { AuthGuard } from '../../guards/auth.guard';
import { AlertasService } from '../../alertas/alertas.service';
import { CheckHorarioDTO } from '../../models/CheckHorarioDTO';
import { AltaPreguntaDto } from '../../models/AltaPreguntaDto';
import { UserService } from '../../services/user.service';
import { PuntuacionDto } from '../../models/puntuacionDto';


@Component({
  selector: 'app-detalleviaje',
  templateUrl: './detalleViaje.component.html',
  styleUrls: ['./detalleViaje.component.css', '../contenedorViaje/contenedorViaje.component.css', '../../editar/formsEditar.css']
})
export class DetalleViajeComponent implements OnInit {
  viaje: any = {};
  provinciaOrigen: string;
  provinciaDestino: string;
  ciudadOrigen: string;
  ciudadDestino: string;
  lugaresDisponibles: number;
  usuario: any = {};
  postulantes: any[] = [];
  viajeros: any[] = [];
  esPostulante = false;
  esViajero = false;
  esCreador = false;
  verAcompaniantes = false;
  verPostulantes = false;
  horaPartidaToShow: any;
  estadoModificar: boolean;
  duracion: any;
  cancelando = false;
  preguntas: any[] = [];
  nuevaPregunta: string;

  constructor(private route: ActivatedRoute, private router: Router, private viajeService: ViajeService,
    private authGuard: AuthGuard, private alertService: AlertasService, private userService: UserService) { }

  async ngOnInit() {
    await this.authGuard.getUser().subscribe(
      usua => {
        this.usuario = usua;
      });
      const id = this.route.snapshot.queryParams['id'];
    await this.viajeService.getById(parseInt(id, 10)).map(res => this.viaje = res)
      .subscribe(data => {
        this.getDatos();
      });
    }

  async getViaje() {
    const id = this.route.snapshot.queryParams['id'];
    await this.viajeService.getById(parseInt(id, 10)).map(res => this.viaje = res)
    .subscribe(data => {
      this.getDatos();
  });
  }
  getDatos() {
    this.viajeros = [];
    this.postulantes = [];
    this.preguntas = [];
    this.viajeService.getPostulantes(this.viaje.id)
      .map(res => Object.keys(res).map(index => this.postulantes.push(res[index])))
      .subscribe(gp => {
        this.viajeService.getViajeros(this.viaje.id)
          .map(res => Object.keys(res).map(index => this.viajeros.push(res[index])))
          .subscribe(gv => {
            this.evaluarEstado();
            this.setDatos();
          });
      });
      this.viajeService.listarPreguntas(this.viaje.id)
      .map(res => Object.keys(res).map(index => this.preguntas.push(res[index])))
      .subscribe(data => this.preguntas.reverse());
  }

  setDatos() {
    this.ciudadDestino = this.viaje.destino.split(',')[0];
    this.provinciaDestino = this.viaje.destino.split(',')[1];
    this.ciudadOrigen = this.viaje.origen.split(',')[0];
    this.provinciaOrigen = this.viaje.origen.split(',')[1];
    this.horaPartidaToShow = this.viaje.horaPartida.split(':');
    this.lugaresDisponibles = this.viaje.cantidadDePlazas - this.viaje.viajeros.length + 1;
    this.duracion = this.viaje.duracion.split(':')[0];

    this.evaluarEstadoModificar();
  }

  evaluarEstadoModificar() {
    this.estadoModificar = (this.postulantes.length > 0) || (this.viajeros.length > 1);
  }

  evaluarEstado() {
    this.esCreador = (this.usuario.id === this.viaje.creador.id);
    this.esPostulante = (this.postulantes.some(p => p.id === this.usuario.id));
    this.esViajero = (this.viajeros.some(p => p.id === this.usuario.id))
  }

  clickCancelarPostulante() {
    this.viajeService.removePostulantes(this.viaje.id, this.usuario.id)
      .subscribe(
        data => {
          this.getDatos();
          this.alertService.addAlert('success', 'Se removió tu solicitud con exito');
        },
        error => {
          this.alertService.addAlert('danger', 'Lo sentimos, no fue posible enviar tu solicitud');
        });
  }

  async clickPostulante() {
    if (await this.authGuard.userAutorizado(this.usuario.id)) {  // usuarioAutorizado

      this.viajeService.addPostulantes(this.viaje.id, this.usuario.id)
        .subscribe(
          data => {
            this.getDatos();
            this.alertService.addAlert('success', 'Tu solicitud fue enviada con exito');
          },
          error => {
            this.alertService.addAlert('danger', 'Lo sentimos, no fue posible enviar tu solicitud');
          });
    } else {
      this.alertService.addAlert('danger',
        'Lo sentimos, no estas autorizado para realizar esta operacion. Revisa tus pagos o puntuaciones pendientes');
    }
  }

  clickCancelarParticipacion() {
    this.viajeService.removeViajero(this.viaje.id, this.usuario.id)
      .subscribe(
        data => {
          this.getDatos();
          this.alertService.addAlert('success', 'Se removió tu participacion al viaje y fuiste penalizado por ello');
        },
        error => {
          this.alertService.addAlert('danger', 'Lo sentimos, no fue posible enviar tu solicitud');
        });
  }

  eliminarViajero(viajero) {
    if (viajero.id === this.viaje.creador.id) {
      this.alertService.addAlert('danger', 'No podes eliminarte a vos mismo!');
    } else {
      this.viajeService.removeViajero(this.viaje.id, viajero.id)
        .subscribe(
          data => {
            this.getDatos();
            this.alertService.addAlert('success', 'Se removió al viajero de manera satisfactoria');
          },
          error => {
            this.alertService.addAlert('danger', 'Lo sentimos, no fue posible procesar tu solicitud');
          });
    }
  }

  cancelarViaje() {
    const pen = this.viajeros.length - 1;
    if (pen > 0) {
      this.alertService.addAlert('danger', '¿Estas seguro de cancelar el viaje? Se te penalizará con ' + pen + ' puntos');
    } else {
      this.alertService.addAlert('danger', '¿Estas seguro de cancelar el viaje? No se te penalizará por esta accion');
    }

    this.cancelando = true;
    setTimeout(() => this.cancelando = false, 4000);
  }

  async okCancelar() {
    this.viajeService.delete(this.viaje.id)
    .subscribe(
      data => {
        this.router.navigate(['/home']);
        this.alertService.addAlert('success', 'Se canceló el viaje de forma exitosa');
        this.penalizar()
      },
      error => {
        this.alertService.addAlert('danger', 'Lo sentimos, no fue posible cancelar tu viaje');
      });

  }

  penalizar() {
    const pen = this.viajeros.length - 1;
    const dto = new PuntuacionDto();
      dto.idPuntuacion = 4;
      dto.Valor = pen * -1;

    dto.comentario = 'Penalizacion por cancelar viaje'
    dto.IdPendiente = 0;
    dto.idRol = 1
    dto.IdUsuarioPuntuador = 5;
    this.userService.Puntuar(dto, this.usuario.id)
    .subscribe(
      data => {
      },
      error => {
        this.alertService.addAlert('danger', 'Lo sentimos, no fue posible enviar la calificacion');
      });
  }


  async aceptarPostulante(postulante) {
    const disponible = await this.usuarioDisponible(postulante);
    if (this.lugaresDisponibles === 0) {
      this.alertService.addAlert('danger', 'Lo sentimos, no hay lugar en el viaje');
    } else if (!disponible) {
      this.alertService.addAlert('danger', 'Lo sentimos, el usuario no tiene horarios disponibles para viajar');
    } else {
      this.viajeService.addViajero(this.viaje.id, postulante.id)
        .subscribe(
          data => {
            this.getDatos();
            this.alertService.addAlert('success', 'Se aceptó al usuario en el viaje');
          },
          error => {
            this.alertService.addAlert('danger', 'Lo sentimos, no fue posible enviar tu solicitud');
          });
    }
  }

  async usuarioDisponible(postulante) {
    const checkHorario = new CheckHorarioDTO();
    checkHorario.duracion = this.viaje.duracion;
    checkHorario.horaPartida = this.viaje.horaPartida;
    checkHorario.diasDeViaje = this.viaje.diasDeViaje;
    const response = await this.authGuard.tieneHorariosDisponibles(checkHorario, postulante.id);
    return response;
  }

  generarPregunta() {
    const dto = new AltaPreguntaDto();

    dto.enunciado = this.nuevaPregunta;
    this.nuevaPregunta = '';
    dto.idUsuario = this.usuario.id;
    dto.idViaje = this.viaje.id;
    this.userService.GenerarPregunta(dto)
    .subscribe(
      data => {
        this.alertService.addAlert('success', 'La pregunta se realizó con exito');
        this.getDatos();
      },
      error => {
        this.alertService.addAlert('danger', 'Lo sentimos, no fue posible realizar tu pregunta');
      });
  }

}
