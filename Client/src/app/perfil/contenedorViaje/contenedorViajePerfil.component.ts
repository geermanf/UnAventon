import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Vehiculo } from '../../models/vehiculo';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertasService } from '../../alertas/alertas.service';
import { Router } from '@angular/router';
import { TarjetaService } from '../../services/tarjeta.service';

@Component({
  selector: 'app-contenedorViajePerfil',
  templateUrl: './contenedorViajePerfil.component.html',
  styleUrls: ['./contenedorViajePerfil.component.css', '../../../assets/css/modal.css']
})
export class ContenedorViajePerfilComponent implements OnInit {
  @Input() viaje: any;
  horaPartidaToShow: any;

  constructor(private router: Router,
              private modalService: NgbModal,
              private tarjetaService: TarjetaService,
              private alertService: AlertasService) { }

  ngOnInit() {
    debugger;
    this.horaPartidaToShow = this.viaje.horaPartida.split(':');
  }

 
}
