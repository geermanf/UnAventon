import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Viaje } from '../../models/Viaje';


@Component({
    selector: 'app-contenedorviaje',
    templateUrl: './contenedorViaje.component.html',
    styleUrls: ['./contenedorViaje.component.css']
})

export class ContenedorViajeComponent implements OnInit {
    @Input() viaje: Viaje;
    provinciaOrigen: string;
    provinciaDestino: string;
    ciudadOrigen: string;
    ciudadDestino: string;
    lugaresDisponibles: number;

    constructor(private router: Router) {}

    ngOnInit() {
        this.ciudadDestino = this.viaje.destino.split(',')[0];
        this.provinciaDestino = this.viaje.destino.split(',')[1];
        this.ciudadOrigen = this.viaje.origen.split(',')[0];
        this.provinciaOrigen = this.viaje.origen.split(',')[1];
        this.viaje.horaPartida = this.viaje.horaPartida.split(':');
        this.lugaresDisponibles = this.viaje.cantidadDePlazas - this.viaje.viajeros.length + 1;
    }

    verViaje() {
        this.router.navigate(['/detalleViaje'], { queryParams: { id: this.viaje.id } });
    }


}
