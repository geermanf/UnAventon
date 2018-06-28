import { Component, OnInit } from '@angular/core';
import { Viaje } from '../../models/Viaje';
import { ViajeService } from '../../services/viaje.service';

@Component({
  selector: 'app-verviajes',
  templateUrl: './verViajes.component.html',
  styleUrls: ['./verViajes.component.css']
})
export class VerViajesComponent implements OnInit {
  viajes: Viaje[];

  constructor(private viajeService: ViajeService) { }

  ngOnInit() {
    this.cargarViajes();
  }

  cargarViajes() {
    this.viajes = [];
    this.viajeService.getAll()
      .map(res => Object.keys(res).map(index => this.viajes.push(res[index])))
      .subscribe();
  }

}
