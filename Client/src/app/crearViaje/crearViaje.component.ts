import { Component, OnInit, ViewChild } from '@angular/core';
import { GooglePlaceDirective } from 'ngx-google-places-autocomplete';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { VehiculoService } from '../services/vehiculo.service';
import { AlertasService } from '../alertas/alertas.service';
import { AuthGuard } from '../guards/auth.guard';
import * as moment from 'moment';
import { ViajeService } from '../services/viaje.service';

@Component({
  selector: 'app-crearviaje',
  templateUrl: './crearViaje.component.html',
  styleUrls: ['./crearViaje.component.css', '../editar/formsEditar.css', '../editar/util.css']
})
export class CrearViajeComponent implements OnInit {
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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private vehiculoService: VehiculoService,
    private viajeService: ViajeService,
    private alertService: AlertasService,
    public authGuard: AuthGuard) { }

  ngOnInit() {
    this.getUsuario();
    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate() + 1);
  }

  getUsuario() {
    this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        this.getVehiculos();
        return data;
      },
      error => {
        return error;
      });
  }

  mostrarRango() {return false}

  getVehiculos() {
    this.vehiculos = [];
    this.vehiculoService.getByUserId(this.usuario.id)
      .map(res => Object.keys(res).map(index => this.vehiculos.push(res[index])))
      .subscribe();
  }

  actualizarPlazas() {
    this.plazas = [];
    // for (let i = 1; i < ((this.vehiculos.find(v => v.id === this.viaje.vehiculo)).cantidadPlazas); i++) {
    //   this.plazas.push(i);
    // }
    const cantPlazas = ((this.vehiculos.find(v => v.id === this.viaje.vehiculo)).cantidadPlazas);
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

  public origenChange(address: Address) {
    this.viaje.origen = address.formatted_address;
  }

  public destinoChange(address: Address) {
    this.viaje.destino = address.formatted_address;
  }

  register() {
    this.viaje.creador = this.usuario.id;
    this.viajeService.create(this.viaje)
        .subscribe(
            data => {
                this.alertService.addAlert('success', 'El viaje se creó correctamente');
                this.router.navigate(['/home']);
            },
            error => {
                this.alertService.addAlert('danger', 'Lo sentimos, hubo un problema al crear tu viaje, itentalo nuevamente');
            });
}



}
