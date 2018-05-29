import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { TipoTarjeta } from '../models/TipoTarjeta';
import { Tarjeta } from '../models/tarjeta';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TipoTarjetaService {
    constructor(private http: HttpClient) { }

    getAll(): Observable<Tarjeta[]> {
        return this.http.get<Tarjeta[]>('http://localhost:5000/api/TipoTarjeta/Listar');
    }

}
