import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from '../guards/auth.guard';
import { UserService } from '../services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertasService } from '../alertas/alertas.service';
import { VehiculoService } from '../services/vehiculo.service';
import { TarjetaService } from '../services/tarjeta.service';
import { Tarjeta } from '../models/tarjeta';
import { Vehiculo } from '../models/vehiculo';
import { TabsetComponent, TabDirective } from 'ngx-bootstrap/tabs';

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
  mostrarFormularioVehiculos = false;
  mostrarFormularioTarjetas = false;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private vehiculoService: VehiculoService,
    private tarjetaService: TarjetaService,
    private alertService: AlertasService,
    private modalService: NgbModal,
    public authGuard: AuthGuard) { }

  show(data: TabDirective): void {
    this.staticTabs.tabs.forEach(e => e.customClass = 'no-visible');
    setTimeout(() => data.customClass = 'visible', 100);
  }

  ngOnInit() {
    const tabId = this.route.snapshot.queryParams['tabId'] === undefined ? 0 : this.route.snapshot.queryParams['tabId'];
    this.show(this.staticTabs.tabs[tabId]);
    this.staticTabs.tabs[tabId].active = true;

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
    this.vehiculos = [];
    this.vehiculoService.getByUserId(this.usuario.id)
      .map(res => Object.keys(res).map(index => this.vehiculos.push(res[index])))
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
