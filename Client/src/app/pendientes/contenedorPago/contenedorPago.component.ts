import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-contenedorPago',
  templateUrl: './contenedorPago.component.html',
  styleUrls: ['./contenedorPago.component.css', '../../../assets/css/modal.css']
})
export class ContenedorPagoComponent implements OnInit {
 

  constructor( 
    private modalService: NgbModal,
  ) { }

  ngOnInit() {
   
  }
  abrirModalPagar(pagar) {
    this.modalService.open(pagar);
  }
 
}
