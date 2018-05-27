import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertasService } from '../../alertas/alertas.service';
import { AuthenticationService } from '../../services/authentication.service';
import { AuthGuard } from '../../guards/auth.guard';
import { UserService } from '../../services/user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-borrarcuenta',
  templateUrl: './borrarCuenta.component.html',
  styleUrls: ['../formsEditar.css', '../util.css', './borrarCuenta.component.css']
})
export class BorrarCuentaComponent implements OnInit {
  pwdViejo = '';
  usuario: any = {};

  constructor(private route: ActivatedRoute,
    private router: Router,
    public authGuard: AuthGuard,
    private authenticationService: AuthenticationService,
    private alertService: AlertasService,
    private userService: UserService,
    private modalService: NgbModal) {}

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

  contraseniaCorrecta() {
    return (this.pwdViejo === this.usuario.password);
  }

  sendNotification() {

    if (!this.contraseniaCorrecta()) {
      this.alertService.addAlert('danger', 'Las contraseña es incorrecta, por favor, intenta nuevamente');

      this.pwdViejo = '';

    }

  }

  eliminarCuentaModal(borrarCuentaModal) {
    this.modalService.open(borrarCuentaModal);
  }

  eliminarCuenta() {
    this.userService.delete(this.usuario.id)
      .subscribe(
        data => {
          this.authenticationService.logout();
          this.router.navigate(['/home']);
          this.alertService.addAlert('success', 'La cuenta fue eliminada con exito. Gracias por usar Un Aventón');
        },
        error => {
          this.alertService.addAlert('danger', 'Lo sentimos, no fue posible eliminar la cuenta');
        });
  }
}
