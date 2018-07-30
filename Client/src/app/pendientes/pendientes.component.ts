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
import { ViajeService } from '../services/viaje.service';

@Component({
  selector: 'app-pendientes',
  templateUrl: './pendientes.component.html',
  styleUrls: ['./pendientes.component.css', '../../assets/css/modal.css']
})
export class PendientesComponent implements OnInit {
 
  

  constructor() { }

 

  ngOnInit() {
   
  }
 

}
