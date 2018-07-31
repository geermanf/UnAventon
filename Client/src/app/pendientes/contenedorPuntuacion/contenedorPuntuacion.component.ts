import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-contenedorPuntuacion',
  templateUrl: './contenedorPuntuacion.component.html',
  styleUrls: ['./contenedorPuntuacion.component.css', '../../../assets/css/modal.css']
})
export class ContenedorPuntuacionComponent implements OnInit {
 

  constructor(
    private modalService: NgbModal,
  ) { }

  ngOnInit() {
   
  }
  abrirModalPuntuar(puntuar) {
    this.modalService.open(puntuar);
  }
}
