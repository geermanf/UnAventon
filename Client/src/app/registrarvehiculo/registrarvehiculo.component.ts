import { Component, OnInit } from '@angular/core';
import { Vehiculo } from '../models/vehiculo';

@Component({
  selector: 'app-registrarvehiculo',
  templateUrl: './registrarvehiculo.component.html',
  styleUrls: ['./registrarvehiculo.component.css']
})
export class RegistrarvehiculoComponent implements OnInit {
 vehiculo:  any = {};

  constructor() { }

  ngOnInit() {
  }

}
