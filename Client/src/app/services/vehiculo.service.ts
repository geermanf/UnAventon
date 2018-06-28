import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Vehiculo } from '../models/vehiculo';
import { Observable } from 'rxjs';

@Injectable()
export class VehiculoService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get('http://localhost:5000/api/Vehiculo/Listar');
    }

    ExisteVehiculo(patente: string, userId: number) {
        return this.http.get('http://localhost:5000/api/User/ExisteVehiculo?patente=' + patente + '&userId=' + userId);
    }

    getById(id: number) {
        return this.http.post('http://localhost:5000/api/Vehiculo/ListarPorId', id);
    }

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

    VehiculoLibre(id: number): Promise<boolean> {
        return this.http.get<boolean>('http://localhost:5000/api/Vehiculo/VehiculoLibre?vehiculoId=' + id).toPromise();
    }

}
