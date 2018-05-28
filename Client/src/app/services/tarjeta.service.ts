import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Tarjeta } from '../models/tarjeta';

@Injectable()
export class TarjetaService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get('http://localhost:5000/api/Tarjeta/GetAll');
    }

    getById(id: number) {
        return this.http.post('http://localhost:5000/api/Tarjeta/ListarPorId', id);
    }

    create(tarjeta: Tarjeta) {
        return this.http.post('http://localhost:5000/api/Tarjeta/Registrar', tarjeta);
    }

    update(tarjeta: Tarjeta) {
        return this.http.post('http://localhost:5000/api/Tarjeta/Modificar', tarjeta);
    }

    delete(id: number) {
        return this.http.post('http://localhost:5000/api/Tarjeta/Borrar', id);
    }

    getByUserId(id: number) {
        return this.http.get('http://localhost:5000/api/User/ListarTarjetas?id=' + id);
    }

}
