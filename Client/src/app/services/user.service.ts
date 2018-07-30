import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/User';
import { Observable } from 'rxjs/Observable';
import { CheckHorarioDTO } from '../models/CheckHorarioDTO';
import { Puntuacion } from '../models/puntuacion';

@Injectable()
export class UserService {
    constructor(private http: HttpClient) { }

    getAll(): Observable<User> {
        return this.http.get<User>('http://localhost:5000/api/User/Listar');
    }

    getById(id: number): Observable<User> {
        return this.http.post<User>('http://localhost:5000/api/User/ListarPorId', id);
    }

    getByEmail(email: string): Observable<User> {
        return this.http.post<User>('http://localhost:5000/api/User/ListarPorEmail', email);
    }

    create(user: User): Observable<User> {
        return this.http.post<User>('http://localhost:5000/api/User/Registrar', user);
    }

    update(user: User): Observable<User> {
        return this.http.post<User>('http://localhost:5000/api/User/Modificar', user);
    }

    delete(id: number): Observable<User> {
        return this.http.post<User>('http://localhost:5000/api/User/Borrar', id);
    }

    TieneCalificacionesPendientes(id: number): Observable<boolean> {
        return this.http.get<boolean>('http://localhost:5000/api/User/TieneCalificacionesPendientes?id=' + id);
    }

    TienePagosPendientes(id: number): Observable<boolean> {
        return this.http.get<boolean>('http://localhost:5000/api/User/TienePagosPendientes?id=' + id);
    }

    executeLogin(email: string, password: string): Observable<User> {
        return this.http.post<User>('http://localhost:5000/api/Authentificate', { email: email, password: password })
    }

    TieneHorarioLibre(dtoClass: CheckHorarioDTO, userId: number): Observable<boolean> {
        return this.http.post<boolean>('http://localhost:5000/api/User/HorarioLibrePara?userId=' + userId, dtoClass);
    }

    ListarReputacionConductor(id: number): Observable<Puntuacion> {
        return this.http.get<Puntuacion>('http://localhost:5000/api/ListarReputacionConductor?id=' + id);
    }

    ListarReputacionViajero(id: number): Observable<Puntuacion> {
        return this.http.get<Puntuacion>('http://localhost:5000/api/ListarReputacionViajero?id=' + id);
    }

    // Puntuar(puntuacionDTO: string, password: string): Observable<User> {
    //     return this.http.post<User>('http://localhost:5000/api/Authentificate', { email: email, password: password })
    // } TODO

    ListarPuntuacionesPendientes(id: number): Observable<Puntuacion> {
        return this.http.get<Puntuacion>('http://localhost:5000/api/ListarPuntuacionesPendientes?id=' + id);
    }

}
