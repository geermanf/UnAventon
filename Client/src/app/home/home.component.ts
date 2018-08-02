import { Component, OnInit } from '@angular/core';
import { AuthGuard } from '../guards/auth.guard';
import { ViajeService } from '../services/viaje.service';
import { Viaje } from '../models/Viaje';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

        viajes: Viaje[];

        constructor(private viajeService: ViajeService, public authGuard: AuthGuard) { }
        ngOnInit() {
          this.cargarViajes();
        }
        cargarViajes() {
          this.viajes = [];
          this.viajeService.getAllProximos()
            .map(res => Object.keys(res).map(index => this.viajes.push(res[index])))
            .subscribe();
        }
}
