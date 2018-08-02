import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/User';
import { Observable } from 'rxjs/Observable';
import { CheckHorarioDTO } from '../models/CheckHorarioDTO';
import { Puntuacion } from '../models/puntuacion';
import { Calificacion } from '../models/calificacion';
import { PuntuacionDto } from '../models/puntuacionDto';
import { Pago } from '../models/pago';
import { PagoDto } from '../models/pagoDto';
import { Pregunta } from '../models/pregunta';
import { ResponderPreguntaDto } from '../models/ResponderPreguntaDto';
import { AltaPreguntaDto } from '../models/AltaPreguntaDto';

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

    ListarReputacionConductor(id: number): Observable<Calificacion> {
        return this.http.get<Calificacion>('http://localhost:5000/api/User/ListarReputacionConductor?id=' + id);
    }

    ListarReputacionViajero(id: number): Observable<Calificacion> {
        return this.http.get<Calificacion>('http://localhost:5000/api/User/ListarReputacionViajero?id=' + id);
    }

    Puntuar(puntuacionDTO: PuntuacionDto, userId: number): Observable<boolean> {
        return this.http.post<boolean>('http://localhost:5000/api/User/Puntuar?userId=' + userId, puntuacionDTO);
    }

    ListarPuntuacionesPendientes(id: number): Observable<Calificacion> {
        return this.http.get<Calificacion>('http://localhost:5000/api/User/ListarPuntuacionesPendientes?id=' + id);
    }

    ListarPagosPendientes(id: number): Observable<Pago> {
        return this.http.get<Pago>('http://localhost:5000/api/User/ListarPagosPendientes?id=' + id);
    }

    PagarViaje(dto: PagoDto): Observable<boolean> {
        return this.http.post<boolean>('http://localhost:5000/api/User/PagarViaje', dto);
    }

    ListarPreguntasPendientes(id: number): Observable<Pregunta> {
        return this.http.get<Pregunta>('http://localhost:5000/api/User/ListarPreguntasPendientes?id=' + id);
    }

    ResponderPregunta(dto: ResponderPreguntaDto): Observable<boolean> {
        return this.http.post<boolean>('http://localhost:5000/api/User/ResponderPregunta', dto);
    }

    GenerarPregunta(dto: AltaPreguntaDto): Observable<boolean> {
        return this.http.post<boolean>('http://localhost:5000/api/User/GenerarPregunta', dto);
    }
}
