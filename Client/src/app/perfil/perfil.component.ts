import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from '../guards/auth.guard';
import { UserService } from '../services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertasService } from '../alertas/alertas.service';
import { VehiculoService } from '../services/vehiculo.service';
import { TarjetaService } from '../services/tarjeta.service';
import { TabsetComponent, TabDirective } from 'ngx-bootstrap/tabs';
import { ViajeService } from '../services/viaje.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css', '../../assets/css/modal.css']
})
export class PerfilComponent implements OnInit {
  @ViewChild('perfilTabs') staticTabs: TabsetComponent;
  urlFoto: any;
  usuario: any = {};
  vehiculos: any[] = [];
  tarjetas: any[] = [];
  vehiculoForEdit: any;
  mostrarFormularioVehiculos = false;
  mostrarFormularioTarjetas = false;
  mostrarFormularioEditarVehiculos = false;
  viajes: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private vehiculoService: VehiculoService,
    private viajeService: ViajeService,
    private tarjetaService: TarjetaService,
    private alertService: AlertasService,
    private modalService: NgbModal,
    public authGuard: AuthGuard) { }

  hayFormulariosActivos() {
    return (this.mostrarFormularioVehiculos || this.mostrarFormularioTarjetas || this.mostrarFormularioEditarVehiculos)
  }

  ngOnInit() {
    const tabId = this.route.snapshot.queryParams['tabId'] === undefined ? 0 : this.route.snapshot.queryParams['tabId'];
    this.staticTabs.tabs[tabId].active = true;

    this.usuario = this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        this.getVehiculos();
        this.getTarjetas();
        this.getViajes();
        return data;
      },
      error => {
        return error;
      });
  }

  returnToEdit(data) {
    this.vehiculoForEdit = data;
    this.mostrarFormularioEditarVehiculos = true;
  }

  getVehiculos() {
    this.vehiculos = [];
    this.vehiculoService.getByUserId(this.usuario.id)
      .map(res => Object.keys(res).map(index => this.vehiculos.push(res[index])))
      .subscribe();
  }

  getViajes() {
    this.viajes = [];
    this.viajeService.getViajesRealizados(this.usuario.id)
      .map(res => Object.keys(res).map(index => this.viajes.push(res[index])))
      .subscribe();
  }
  getTarjetas() {
    this.tarjetas = [];
    this.tarjetaService.getByUserId(this.usuario.id)
      .map(res => Object.keys(res).map(index => this.tarjetas.push(res[index])))
      .subscribe();
  }

  ocultarFormVehiculos() {
    this.mostrarFormularioVehiculos = false
    this.getVehiculos();
  }

  ocultarFormTarjetas() {
    this.mostrarFormularioTarjetas = false
    this.getTarjetas();
  }

  ocultarFormEditarVehiculos() {
    this.mostrarFormularioEditarVehiculos = false
    this.getVehiculos();
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
