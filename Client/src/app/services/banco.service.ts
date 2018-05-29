import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Banco } from '../models/banco';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BancoService {
    constructor(private http: HttpClient) { }

    getAll(): Observable<Banco[]> {
        return this.http.get<Banco[]>('http://localhost:5000/api/Banco/Listar');
    }

}
