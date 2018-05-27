import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { AlertasService } from '../../alertas/alertas.service';
import { AuthGuard } from '../../guards/auth.guard';

@Component({
  selector: 'app-cambiarcontrasenia',
  templateUrl: './cambiarContrasenia.component.html',
  styleUrls: ['../formsEditar.css', '../util.css']
})
export class CambiarContraseniaComponent implements OnInit {
  pwdViejo = '';
  pwdNuevo = '';
  pwdNuevoRepeated = '';
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
  contraseniasValidas() {
    return (this.contraseniasIguales() && this.contraseniaCorrecta());
  }

  contraseniaCorrecta() {
    return (this.pwdViejo === this.usuario.password);
  }

  contraseniasIguales() {
    return (this.pwdNuevo === this.pwdNuevoRepeated);
  }

  sendNotification() {
    if (!this.contraseniaCorrecta()) {
      this.alertService.addAlert('danger', 'Las contraseña es incorrecta, por favor, intenta nuevamente');

      this.pwdViejo = '';

    } else if (!this.contraseniasIguales()) {
      this.alertService.addAlert('danger', 'Las contraseñas no son iguales, por favor, intenta nuevamente');

      this.pwdNuevo = '';
      this.pwdNuevoRepeated = '';
    }

  }

  register() {
    this.usuario.password = this.pwdNuevo;
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
