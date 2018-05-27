import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { AlertasService } from '../../alertas/alertas.service';
import { AuthGuard } from '../../guards/auth.guard';
import { calcularEdad } from '../../registrarse/calcularEdad';

@Component({
  selector: 'app-editarperfil',
  templateUrl: './editarPerfil.component.html',
  styleUrls: ['../formsEditar.css', '../util.css']
})
export class EditarPerfilComponent implements OnInit {
  usuario: any = {};

  constructor(
      private router: Router,
      private userService: UserService,
      private alertService: AlertasService,
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

  esMayorDeEdad() {
      const años = calcularEdad(this.usuario.fechaDeNacimiento);
      return (años >= 18);
  }

  sendNotification() {
      if (!this.esMayorDeEdad()) {
          this.alertService.addAlert('danger', 'Lo sentimos, debes ser mayor de edad para usar Un Aventon');
      }
  }

  register() {
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
