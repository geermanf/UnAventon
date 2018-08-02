import { Component, OnInit } from '@angular/core';
import { AlertasService } from '../alertas/alertas.service';
import { Router } from '../../../node_modules/@angular/router';


@Component({
  selector: 'app-contacto',
  templateUrl: './contactoAdmin.component.html',
  styleUrls: ['./contactoAdmin.component.css']
})
export class ContactoAdminComponent implements OnInit {
  desc: any;
  mail: any;

  constructor(private router: Router, private alertService: AlertasService) { }

  ngOnInit() {
  }

  send() {
    this.router.navigate(['/home']);
    this.alertService.addAlert('success', 'Su consulta fue enviada con exito');
  }
}
