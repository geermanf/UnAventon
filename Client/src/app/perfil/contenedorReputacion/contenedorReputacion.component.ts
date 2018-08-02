import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../../services/user.service';
import { AuthGuard } from '../../guards/auth.guard';

@Component({
  selector: 'app-contenedorReputacion',
  templateUrl: './contenedorReputacion.component.html',
  styleUrls: ['./contenedorReputacion.component.css']
})
export class ContenedorReputacionComponent implements OnInit {
  @Input() tipo: string;
  usuario: any;
  value: number;
  calificacionesViajero: any[] = [];
  calificacionesConductor: any[] = [];
  calificacionValorViajero: any = 0;
  calificacionValorConductor: any = 0;

  constructor(private userService: UserService, public authGuard: AuthGuard) { }

  ngOnInit() {

    this.usuario = this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        this.getCalificaciones();
        return data;
      },
      error => {
        return error;
      });
  }

  getCalificaciones() {
    if (this.tipo === 'viajero') {
      this.userService.ListarReputacionViajero(this.usuario.id)
        .map(res => Object.keys(res).map(index => this.calificacionesViajero.push(res[index])))
        .subscribe(data => {
          this.calcularReputacionViajero();
        });
    } else {
      this.userService.ListarReputacionConductor(this.usuario.id)
        .map(res => Object.keys(res).map(index => this.calificacionesConductor.push(res[index])))
        .subscribe(data => this.calcularReputacionConductor());
    }
  }

  calcularReputacionViajero() {
    this.calificacionesViajero.forEach(d => this.calificacionValorViajero = this.calificacionValorViajero + d.valor)
    this.value = this.calificacionValorViajero
  }

  calcularReputacionConductor() {
    this.calificacionesConductor.forEach(d => this.calificacionValorConductor = this.calificacionValorConductor + d.valor);
    this.value = this.calificacionValorConductor
  }

}
