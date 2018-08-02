import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { GooglePlaceDirective } from 'ngx-google-places-autocomplete';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { VehiculoService } from '../services/vehiculo.service';
import { AlertasService } from '../alertas/alertas.service';
import { AuthGuard } from '../guards/auth.guard';
import * as moment from 'moment';
import * as dateHelper from '../../assets/js/dateHelper';
import { ViajeService } from '../services/viaje.service';
import { CheckHorarioDTO } from '../models/CheckHorarioDTO';
import { ViajeDto } from '../models/viajeDto';

@Component({
  selector: 'app-modificarviaje',
  templateUrl: './modificarViaje.component.html',
  styleUrls: ['./modificarViaje.component.css', '../editar/formsEditar.css', '../editar/util.css']
})
export class ModificarViajeComponent implements OnInit {
  @ViewChild('origen') origen: GooglePlaceDirective;
  @ViewChild('destino') destino: GooglePlaceDirective;
  minDate: Date;
  options = {
    types: [],
    componentRestrictions: { country: 'AR' }
  }
  usuario: any = {};
  viaje: any = {};
  vehiculos: any[] = [];
  plazas: number[]
  usarRango: false;
  rangoDeFechas: any[];
  orig: any;
  dest: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehiculoService: VehiculoService,
    private viajeService: ViajeService,
    private alertService: AlertasService,
    public authGuard: AuthGuard) { }

  async ngOnInit() {
    this.getUsuario();
    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate() + 1);
  }

  getViaje() {
    const id = this.route.snapshot.queryParams['id'];
    this.viajeService.getAllById(parseInt(id, 10)).map(res => this.viaje = res)
    .subscribe(data => {this.getVehiculos(); this.orig = data.origen; this.dest = data.destino})
  }

  getUsuario() {
    this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        this.getViaje();
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
      .subscribe(data => this.actualizarPlazasInicial() );
  }

  actualizarPlazas() {
    this.plazas = [];
    const cantPlazas = ((this.vehiculos.find(v => v.id === this.viaje.vehiculo)).cantidadPlazas);
    this.plazas = Array(cantPlazas).fill(0).map((x, i) => i + 1).reverse();
    this.viaje.cantidadDePlazas = this.plazas[0];
  }

  actualizarPlazasInicial() {
    this.plazas = [];
    const cantPlazas = ((this.vehiculos.find(v => v.id === this.viaje.vehiculo.id)).cantidadPlazas);
    this.plazas = Array(cantPlazas).fill(0).map((x, i) => i + 1).reverse();
    this.viaje.cantidadDePlazas = this.plazas[0];
  }

  validarFecha() {
    if (this.viaje.fechaPartida !== undefined) {
      return (moment(this.viaje.fechaPartida).isAfter(moment(new Date())));
    }
  }

  placesAreValids() {
    return (this.viaje.origen !== undefined && this.viaje.destino !== undefined);
  }

  costoValido() {
    if (this.viaje.costo !== undefined) {
      return (this.viaje.costo >= 0);
    }
  }

  mostrarRango() {
    return this.usarRango;
  }

  public origenChange(address: Address) {
    this.viaje.origen = address.formatted_address;
  }

  public destinoChange(address: Address) {
    this.viaje.destino = address.formatted_address;
  }

  async register() {
    const viajeDto = new ViajeDto()
      viajeDto.origen = this.viaje.origen;
      viajeDto.destino = this.viaje.destino;
      viajeDto.descripcion = this.viaje.descripcion;
      viajeDto.duracion = this.viaje.duracion;
      viajeDto.idViaje = this.viaje.id;
      viajeDto.costo = this.viaje.costo;
      viajeDto.vehiculo = this.viaje.vehiculo.id;
      viajeDto.cantidadDePlazas = this.viaje.cantidadDePlazas;

      if (await this.authGuard.userAutorizado(this.usuario.id)) {  // usuarioAutorizado
        this.viajeService.update(viajeDto)
          .subscribe(
            data => {
              this.alertService.addAlert('success', 'El viaje se modificó correctamente');
              this.router.navigate(['/detalleViaje'], { queryParams: { id: viajeDto.idViaje } });
            },
            error => {
              this.alertService.addAlert('danger', 'Lo sentimos, hubo un problema al modificar tu viaje, itentalo nuevamente');
            });
      } else {
        this.alertService.addAlert('danger',
          'Lo sentimos, no estas autorizado para realizar esta operacion. Revisa tus pagos o puntuaciones pendientes');
      }
  }
}

