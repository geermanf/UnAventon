import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from '../guards/auth.guard';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { AlertasService } from '../alertas/alertas.service';
import { VehiculoService } from '../services/vehiculo.service';
import { TarjetaService } from '../services/tarjeta.service';
import { Tarjeta } from '../models/tarjeta';
import { Vehiculo } from '../models/vehiculo';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css', '../../assets/css/modal.css']
})
export class PerfilComponent implements OnInit {
  urlFoto: any;
  usuario: any = {};
  vehiculos: any[] = [];
  tarjetas: any[] = [];
  mostrarFormularioVehiculos = false;
  mostrarFormularioTarjetas = false;

  constructor(
    private router: Router,
    private userService: UserService,
    private vehiculoService: VehiculoService,
    private tarjetaService: TarjetaService,
    private alertService: AlertasService,
    private modalService: NgbModal,
    public authGuard: AuthGuard) { }

  ngOnInit() {
    this.usuario = this.authGuard.getUser().subscribe(
              data => {
                  this.usuario = data;
                  this.getVehiculos();
                  this.getTarjetas();
                  return data;
              },
              error => {
                  return error;
              });

  }

  getVehiculos() {
    // this.vehiculos = [];
    // this.vehiculoService.getByUserId(this.usuario.id)
    // .map( res => Object.keys(res).map(index => this.vehiculos.push(res[index])))
    // .subscribe();
    const v = new Vehiculo();
    v.id = 1; v.cantidadPlazas = 4; v.color = 'Negro'; v.foto = '../assets/img/vehiculoNoDisponible.png';
    v.marca = 'Audi'; v.modelo = 'A3'; v.patente = 'HTR 456';
    const v2 = new Vehiculo();
    v2.id = 1; v2.cantidadPlazas = 4; v2.color = 'Negro'; v2.foto = '../assets/img/vehiculoNoDisponible.png';
    v2.marca = 'Audi'; v2.modelo = 'A3'; v2.patente = 'HTR 456';
    this.vehiculos.push(v); this.vehiculos.push(v2);
  }

  getTarjetas() {
    // this.tarjetas = [];
    // this.tarjetaService.getByUserId(this.usuario.id)
    // .map( res => Object.keys(res).map(index => this.tarjetas.push(res[index])))
    // .subscribe();
    if (this.tarjetas.length !== 0) {
      this.tarjetas.pop()
    } else {
      const t = new Tarjeta();
      t.id = 1; t.banco = 'Santander Rio'; t.fechaVencimiento = new Date('05/05/2020');
      t.nombreTitular = 'German Flores'; t.numeroTarjeta = 4154948576041582; t.tipoTarjeta = 'Visa';
      const t2 = new Tarjeta();
      t2.id = 1; t2.banco = 'Galicia'; t2.fechaVencimiento = new Date('05/05/2020');
      t2.nombreTitular = 'German Flores'; t2.numeroTarjeta = 4154948576041582; t2.tipoTarjeta = 'Mastercard';
      this.tarjetas.push(t); this.tarjetas.push(t2);
    }
  }

  ocultarFormVehiculos() {
    this.mostrarFormularioVehiculos = false
    this.getVehiculos();
  }

  ocultarFormTarjetas() {
    this.mostrarFormularioTarjetas = false
    this.getTarjetas();
  }

  abrirModalFoto(cargarFoto) {
    this.modalService.open(cargarFoto);
  }

  cambiarFoto() {
    this.usuario.fotoPerfil = this.urlFoto;
    this.userService.update(this.usuario)
    .subscribe(
        data => {
            this.alertService.addAlert('success', 'Tus datos se modificaron de manera satisfactoria!');
            this.router.navigate(['/perfil']);
        },
        error => {
            this.alertService.addAlert('danger', 'Lo sentimos, no fue posible modificar tus datos');
        });
  }

}
