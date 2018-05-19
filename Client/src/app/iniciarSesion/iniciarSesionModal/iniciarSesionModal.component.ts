import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
    selector: 'app-regmodal',
    templateUrl: './iniciarSesionModal.component.html',
    styleUrls: ['./iniciarSesionModal.component.css']
})

export class IniciarSesionModalComponent implements OnInit {
    model: any = {};
    returnUrl: string;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        public ngxSmartModalService: NgxSmartModalService) { }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();
        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    login() {
        this.authenticationService.login(this.model.email, this.model.password)
            .subscribe(
                data => {
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    // alert fail
                });
    }
}
