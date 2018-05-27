import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from '../guards/auth.guard';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { AlertasService } from '../alertas/alertas.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {
  urlFoto: any;
  usuario: any = {};

  constructor(
    private router: Router,
    private userService: UserService,
    private alertService: AlertasService,
    private modalService: NgbModal,
    public authGuard: AuthGuard) { }

  ngOnInit() {
    this.usuario = this.authGuard.getUser().subscribe(
              data => {
                  this.usuario = data;
                  return data;
              },
              error => {
                  return error;
              });
  }

  abrirModalFoto(cargarFoto) {
    this.modalService.open(cargarFoto);
  }

  cambiarFoto() {
    this.usuario.fotoPerfil = this.urlFoto;
    this.userService.update(this.usuario)
    .subscribe(
        data => {
            this.alertService.addAlert('success', 'Tus datos se modificaron de manera satisfactoria!');
            this.router.navigate(['/perfil']);
        },
        error => {
            this.alertService.addAlert('danger', 'Lo sentimos, no fue posible modificar tus datos');
        });
  }

}
