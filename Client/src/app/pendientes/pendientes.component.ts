import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthGuard } from '../guards/auth.guard';
import { TabsetComponent } from '../../../node_modules/ngx-bootstrap/tabs';
import { ActivatedRoute, Router } from '../../../node_modules/@angular/router';
import { UserService } from '../services/user.service';
import { VehiculoService } from '../services/vehiculo.service';
import { ViajeService } from '../services/viaje.service';
import { TarjetaService } from '../services/tarjeta.service';
import { AlertasService } from '../alertas/alertas.service';
import { NgbModal } from '../../../node_modules/@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-pendientes',
  templateUrl: './pendientes.component.html',
  styleUrls: ['./pendientes.component.css', '../../assets/css/modal.css']
})
export class PendientesComponent implements OnInit {
  usuario: any = {};
  @ViewChild('pTabs') staticTabs: TabsetComponent;
  calificacionesPendientes: any[] = [];
  pagosPendientes: any[] = [];
  preguntasPendientes: any[] = [];

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

  ngOnInit() {
    const tabId = this.route.snapshot.queryParams['tabId'] === undefined ? 0 : this.route.snapshot.queryParams['tabId'];
    this.staticTabs.tabs[tabId].active = true;
    this.getUsuario();
  }

  getUsuario() {

    this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        this.getCalificacionesPendientes();
        this.getPagosPendientes();
        this.getPreguntasPendientes();
        return data;
      },
      error => {
        return error;
      });
  }

  getCalificacionesPendientes() {
    this.calificacionesPendientes = [];
    this.userService.ListarPuntuacionesPendientes(this.usuario.id)
    .map(res => Object.keys(res).map(index => this.calificacionesPendientes.push(res[index])))
    .subscribe();
  }

  getPagosPendientes() {
    this.pagosPendientes = [];
    this.userService.ListarPagosPendientes(this.usuario.id)
    .map(res => Object.keys(res).map(index => this.pagosPendientes.push(res[index])))
    .subscribe();
  }

  getPreguntasPendientes() {
    this.preguntasPendientes = [];
    this.userService.ListarPreguntasPendientes(this.usuario.id)
    .map(res => Object.keys(res).map(index => this.preguntasPendientes.push(res[index])))
    .subscribe();
  }
}
