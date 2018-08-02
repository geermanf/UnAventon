import { Component, OnInit, ViewChild } from '@angular/core';
import { Viaje } from '../../models/Viaje';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { ViajeService } from '../../services/viaje.service';
import * as moment from 'moment';
import { Address } from '../../../../node_modules/ngx-google-places-autocomplete/objects/address';
import { GooglePlaceDirective } from '../../../../node_modules/ngx-google-places-autocomplete';
import { FiltrosDto } from '../../models/filtrosDto';

@Component({
  selector: 'app-verviajes',
  templateUrl: './verViajes.component.html',
  styleUrls: ['./verViajes.component.css']
})
export class VerViajesComponent implements OnInit {
  viajes: Viaje[] = [];
  viajesFiltrados: Viaje[] = [];
  origen: string;
  destino: string;
  fecha: any;
  @ViewChild('origen') o: GooglePlaceDirective;
  @ViewChild('destino') d: GooglePlaceDirective;
  options = {
    types: [],
    componentRestrictions: { country: 'AR' }
  }
  origenSeleccionado: string;
  destinoSeleccionado: string;
  FechaSeleccionada = '';
  constructor(private viajeService: ViajeService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.cargarViajes();
    this.origen = this.route.snapshot.queryParams['origen'] !== undefined ? this.route.snapshot.queryParams['origen'] : '';
    this.destino = this.route.snapshot.queryParams['destino'] !== undefined ? this.route.snapshot.queryParams['destino'] : '';
    this.fecha = this.route.snapshot.queryParams['fecha'] !== undefined ? this.route.snapshot.queryParams['fecha'] : '';
    this.origenSeleccionado = this.origen;
    this.destinoSeleccionado = this.destino;
    this.FechaSeleccionada = '';
  }

  cargarViajes() {
    this.viajes = [];
    this.viajeService.getAllProximos()
      .map(res => Object.keys(res).map(index => this.viajes.push(res[index])))
      .subscribe(data => this.filtrar());
  }

  filtrar() {
    this.origen !== '' ? this.viajesFiltrados = this.viajes.filter(v => v.origen === this.origen) : this.viajesFiltrados = this.viajes;
    this.destino !== '' ? this.viajesFiltrados = this.viajesFiltrados.filter(v => v.destino === this.destino)
      : this.viajesFiltrados = this.viajesFiltrados;
    this.fecha !== '' ? this.viajesFiltrados = this.viajesFiltrados.filter(v => v.diasDeViaje.some(dv => this.evaluarFecha(dv)))
      : this.viajesFiltrados = this.viajesFiltrados;
  }

  evaluarFecha(dv) {
    const f = moment(this.fecha);
    const ret = moment(f).isSame(dv)
    return (ret);
  }

  public origenChange(address: Address) {
    this.origenSeleccionado = address.formatted_address;
  }

  public destinoChange(address: Address) {
    this.destinoSeleccionado = address.formatted_address;
  }

  buscar() {
    if ((this.origenSeleccionado !== '' && this.destinoSeleccionado !== '')
    || (this.origenSeleccionado === '' && this.destinoSeleccionado === '')) {
      this.router.navigate(['/verViajes2'],
          { queryParams: { origen: this.origenSeleccionado, destino: this.destinoSeleccionado, fecha: this.FechaSeleccionada } });
  }
    // const dto = new FiltrosDto();
    // dto.origen = this.origenSeleccionado;
    // dto.destino = this.destinoSeleccionado;
    // dto.fecha = new Date(this.FechaSeleccionada);
    // this.viajeService.filtrarViajes(dto)
    //   .map(res => Object.keys(res).map(index => this.viajesFiltrados.push(res[index])))
    //   .subscribe();
    // this.viajesFiltrados = [];
    // this.origenSeleccionado !== '' ? this.viajesFiltrados = this.viajes.filter(v => v.origen === this.origenSeleccionado)
    //   : this.viajesFiltrados = this.viajes;
    // this.destinoSeleccionado !== '' ? this.viajesFiltrados = this.viajesFiltrados.filter(v => v.destino === this.destinoSeleccionado)
    //   : this.viajesFiltrados = this.viajesFiltrados;
    // this.fecha = this.FechaSeleccionada;
    // this.FechaSeleccionada !== '' ?
    //   this.viajesFiltrados = this.viajesFiltrados.filter(v => v.diasDeViaje.some(dv => this.evaluarFecha(dv)))
    //   : this.viajesFiltrados = this.viajesFiltrados;
  }
}
