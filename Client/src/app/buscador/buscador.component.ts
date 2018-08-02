import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { GooglePlaceDirective } from '../../../node_modules/ngx-google-places-autocomplete';
import { Address } from '../../../node_modules/ngx-google-places-autocomplete/objects/address';


@Component({
    selector: 'app-buscador',
    templateUrl: './buscador.component.html',
    styleUrls: ['./buscador.component.css']
})

export class BuscadorComponent {
    @ViewChild('origen') origen: GooglePlaceDirective;
    @ViewChild('destino') destino: GooglePlaceDirective;
    options = {
        types: [],
        componentRestrictions: { country: 'AR' }
    }
    origenSeleccionado = '';
    destinoSeleccionado = '';
    FechaSeleccionada: any;

    constructor(private router: Router) { }

    public origenChange(address: Address) {
        this.origenSeleccionado = address.formatted_address;
    }

    public destinoChange(address: Address) {
        this.destinoSeleccionado = address.formatted_address;
    }

    buscar() {
        if (this.origenSeleccionado !== '' && this.destinoSeleccionado !== '') {
            this.router.navigate(['/verViajes'],
                { queryParams: { origen: this.origenSeleccionado, destino: this.destinoSeleccionado, fecha: this.FechaSeleccionada } });
        }
    }
}
