import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/User';
import { ApiResponse } from '../models/ApiResponse';

@Injectable()
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        let response = this.http.get<ApiResponse<User>>('http://localhost:5000/api/User/GetAll');
        return response;
    }

    getById(id: number) {
        let response = this.http.get<ApiResponse<User>>('http://localhost:5000/api/User/GetById' + id);
        return response;
    }

    create(user: User) {
        return this.http.post('http://localhost:5000/api/User/Registrar', user);
    }

    update(user: User) {
        return this.http.put('/api/users/' + user.id, user);
    }

    delete(id: number) {
        return this.http.delete('/api/users/' + id);
    }
}
