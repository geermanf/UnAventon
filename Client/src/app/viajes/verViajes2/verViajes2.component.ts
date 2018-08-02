import { Component, OnInit, ViewChild } from '@angular/core';
import { Viaje } from '../../models/Viaje';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-verviajes2',
  templateUrl: './verViajes2.component.html',
  styleUrls: ['./verViajes2.component.css']
})
export class VerViajes2Component implements OnInit {
  origen: string;
  destino: string;
  fecha: any;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.origen = this.route.snapshot.queryParams['origen'] !== undefined ? this.route.snapshot.queryParams['origen'] : '';
    this.destino = this.route.snapshot.queryParams['destino'] !== undefined ? this.route.snapshot.queryParams['destino'] : '';
    this.fecha = this.route.snapshot.queryParams['fecha'] !== undefined ? this.route.snapshot.queryParams['fecha'] : '';

    this.router.navigate(['/verViajes'],
    { queryParams: { origen: this.origen, destino: this.destino, fecha: this.fecha } });
  }
}
