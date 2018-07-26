import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AuthGuard } from '../../guards/auth.guard';
import { AuthenticationService } from '../../services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertasService } from '../../alertas/alertas.service';
import { UserService } from '../../services/user.service';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
    subscription: Subscription;
    private toggleButton: any;
    private sidebarVisible: boolean;
    public logueado: any;
    usuario: any = {};

    constructor(private route: ActivatedRoute, private router: Router, private element: ElementRef,
        public ngxSmartModalService: NgxSmartModalService, public authGuard: AuthGuard,
        private authenticationService: AuthenticationService, private alertService: AlertasService,
        private userService: UserService, private modalService: NgbModal) {

        this.subscription = authGuard.authenticated$.subscribe(
            data => {
                if (this.authGuard.isLogued()) {
                    this.getUser();
                }
            });
        this.sidebarVisible = false;
    }

    open() {
        this.ngxSmartModalService.getModal('regModal').open()
    }

    ngOnInit() {
        const navbar: HTMLElement = this.element.nativeElement;
        this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
        if (this.authGuard.isLogued()) {
            this.getUser();
        }
    }

    getUser() {
        this.usuario = this.authGuard.getUser().subscribe(
            data => {
                this.usuario = data;
                return data;
            },
            error => {
                return error;
            });
    }

    logoutModal(CerrarSesionModal) {
        this.modalService.open(CerrarSesionModal);
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/home']);
        this.alertService.addAlert('info', 'Se cerró sesion en Un Aventón, nos vemos pronto!');
    }

    // FUNCIONALIDAD DE SHOW/HIDE
    sidebarOpen() {
        const toggleButton = this.toggleButton;
        const html = document.getElementsByTagName('html')[0];

        setTimeout(function () {
            toggleButton.classList.add('toggled');
        }, 500);
        html.classList.add('nav-open');

        this.sidebarVisible = true;
    };

    sidebarClose() {
        const html = document.getElementsByTagName('html')[0];
        this.toggleButton.classList.remove('toggled');
        this.sidebarVisible = false;
        html.classList.remove('nav-open');
    };
    sidebarToggle() {
        if (this.sidebarVisible === false) {
            this.sidebarOpen();
        } else {
            this.sidebarClose();
        }
    };
    async usuarioAutorizado() {
        debugger;
        return (await this.authGuard.userAutorizado(this.usuario.id));
    }
    mostrarAlertaNoAutorizado() {
        this.alertService.addAlert('danger',
            'Lo sentimos, no estas autorizado para realizar esta operacion. Revisa tus pagos o puntuaciones pendientes');
    }
}

