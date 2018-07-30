import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Vehiculo } from '../../models/vehiculo';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';
import { TarjetaService } from '../../services/tarjeta.service';

@Component({
  selector: 'app-contenedorPuntuacion',
  templateUrl: './contenedorPuntuacion.component.html',
  styleUrls: ['./contenedorPuntuacion.component.css', '../../../assets/css/modal.css']
})
export class ContenedorPuntuacionComponent implements OnInit {
 

  constructor() { }

  ngOnInit() {
   
  }

 
}
