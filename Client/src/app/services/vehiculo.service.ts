import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Vehiculo } from '../models/vehiculo';

@Injectable()
export class VehiculoService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get('http://localhost:5000/api/Vehiculo/Listar');
    }

    getById(id: number) {
        return this.http.post('http://localhost:5000/api/Vehiculo/ListarPorId', id);
    }

    // create(vehiculo: Vehiculo) {
    //     return this.http.post('http://localhost:5000/api/Vehiculo/Registrar', vehiculo);
    // }

    create(vehiculo: Vehiculo, userId: number) {
        return this.http.post('http://localhost:5000/api/Vehiculo/RegistrarEnUser?userId=' + userId, vehiculo);
    }

    update(vehiculo: Vehiculo) {
        return this.http.post('http://localhost:5000/api/Vehiculo/Modificar', vehiculo);
    }

    delete(id: number) {
        return this.http.post('http://localhost:5000/api/Vehiculo/Borrar', id);
    }

    getByUserId(id: number) {
        return this.http.get('http://localhost:5000/api/User/ListarVehiculos?id=' + id);
    }

}
