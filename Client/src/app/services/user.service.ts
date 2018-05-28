import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/User';

@Injectable()
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get('http://localhost:5000/api/User/GetAll');
    }

    getById(id: number) {
        return this.http.post('http://localhost:5000/api/User/ListarPorId', id);
    }

    getByEmail(email: string) {
        return this.http.post('http://localhost:5000/api/User/ListarPorEmail', email);
    }

    create(user: User) {
        return this.http.post('http://localhost:5000/api/User/Registrar', user);
    }

    update(user: User) {
        return this.http.post('http://localhost:5000/api/User/Modificar', user);
    }

    delete(id: number) {
        return this.http.post('http://localhost:5000/api/User/Borrar', id);
    }

    executeLogin(email: string, password: string) {
        return this.http.post('http://localhost:5000/api/Authentificate', { email: email, password: password })
    }

}
