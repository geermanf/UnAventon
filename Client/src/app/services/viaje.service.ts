import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Viaje } from '../models/Viaje';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ViajeService {
    constructor(private http: HttpClient) { }

    getAll(): Observable<Viaje> {
        return this.http.get<Viaje>('http://localhost:5000/api/Viaje/Listar');
    }

    getById(id: number): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/ListarPorId', id);
    }

    create(viaje: Viaje): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/Crear', viaje);
    }

    update(viaje: Viaje): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/Modificar', viaje);
    }

    delete(id: number): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/Borrar', id);
    }

}
