import { Component, OnInit, } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AuthenticationService } from '../../services/authentication.service';
import { AlertasService } from '../../alertas/alertas.service';

@Component({
    selector: 'app-regmodal',
    templateUrl: './iniciarSesionModal.component.html',
    styleUrls: ['./iniciarSesionModal.component.css']
})

export class IniciarSesionModalComponent implements OnInit {
    model: any = {};
    returnUrl: string;
    showAlert = false;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertasService,
        public ngxSmartModalService: NgxSmartModalService) { }

    ngOnInit() {
    }

    login() {
        this.authenticationService.login(this.model.email, this.model.password)
            .subscribe(
                data => {
                    this.ngxSmartModalService.getModal('regModal').close();
                    this.router.navigate(['/perfil']);
                    this.alertService.addAlert('success', 'Se inició sesion correctamente. Bienvenido a Un Aventón!!');
                },
                error => {
                    this.showAlert = true;
                    setTimeout(() => this.showAlert = false, 4000);
                    this.model.password = '';
                });

    }
}
