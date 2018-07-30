import { Component, OnInit } from '@angular/core';
import { AuthGuard } from '../guards/auth.guard';

@Component({
  selector: 'app-pendientes',
  templateUrl: './pendientes.component.html',
  styleUrls: ['./pendientes.component.css', '../../assets/css/modal.css']
})
export class PendientesComponent implements OnInit {
  usuario: any = {};

  constructor(public authGuard: AuthGuard) { }

  ngOnInit() {
    this.getUsuario();
  }

  getUsuario() {
    this.authGuard.getUser().subscribe(
      data => {
        this.usuario = data;
        return data;
      },
      error => {
        return error;
      });
  }
}
