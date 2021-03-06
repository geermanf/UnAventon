﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Viaje } from '../models/Viaje';
import { Observable } from 'rxjs/Observable';
import { User } from '../models/User';
import { ViajeDto } from '../models/viajeDto';
import { Pregunta } from '../models/pregunta';
import { FiltrosDto } from '../models/filtrosDto';

@Injectable()
export class ViajeService {
    constructor(private http: HttpClient) { }

    getAll(): Observable<Viaje> {
        return this.http.get<Viaje>('http://localhost:5000/api/Viaje/ListarViajes');
    }

    getAllProximos(): Observable<Viaje> {
        return this.http.get<Viaje>('http://localhost:5000/api/Viaje/ListarViajesProximos');
    }

    getById(id: number): Observable<Viaje> {
        return this.http.get<Viaje>('http://localhost:5000/api/Viaje/ListarId?id=' + id);
    }

    getAllById(id: number): Observable<Viaje> {
        return this.http.get<Viaje>('http://localhost:5000/api/Viaje/ListarViajeCompleto?id=' + id);
    }

    create(viaje: Viaje): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/Crear', viaje);
    }

    update(viaje: ViajeDto): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/Update', viaje);
    }

    delete(id: number): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/Delete', id);
    }

    addPostulantes(idViaje: number, idPostulante: number): Observable<any> {
        return this.http.get<any>('http://localhost:5000/api/Viaje/AgregarPostulante?idViaje=' + idViaje + '&idPostulante=' + idPostulante);
    }

    addViajero(idViaje: number, idViajero: number): Observable<any> {
        return this.http.get<any>('http://localhost:5000/api/Viaje/AgregarViajero?idViaje=' + idViaje + '&idViajero=' + idViajero);
    }

    removePostulantes(idViaje: number, idPostulante: number): Observable<any> {
        return this.http.get<any>('http://localhost:5000/api/Viaje/BorrarPostulante?idViaje=' + idViaje + '&idPostulante=' + idPostulante);
    }

    removeViajero(idViaje: number, idViajero: number): Observable<any> {
        return this.http.get<any>('http://localhost:5000/api/Viaje/BorrarViajero?idViaje=' + idViaje + '&idViajero=' + idViajero);
    }

    getPostulantes(idViaje: number): Observable<User> {
        return this.http.get<User>('http://localhost:5000/api/Viaje/ListarPostulantes?idViaje=' + idViaje);
    }

    getViajeros(idViaje: number): Observable<User> {
        return this.http.get<User>('http://localhost:5000/api/Viaje/ListarViajeros?idViaje=' + idViaje);
    }

    getViajesRealizados(idUsuario: number): Observable<User> {
        return this.http.get<User>('http://localhost:5000/api/Viaje/ListarViajesRealizados?idUsuario=' + idUsuario);
    }

    listarPreguntas(id: number): Observable<Pregunta> {
        return this.http.get<Pregunta>('http://localhost:5000/api/Viaje/ListarPreguntas?id=' + id);
    }

    filtrarViajes(dto: FiltrosDto): Observable<Viaje> {
        return this.http.post<Viaje>('http://localhost:5000/api/Viaje/FiltrarViajes', dto);
    }

}
