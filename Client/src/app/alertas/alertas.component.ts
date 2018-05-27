import { Input, Component, OnInit } from '@angular/core';
import { AlertasService, IAlert } from './alertas.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-alertas',
  templateUrl: './alertas.component.html',
  styleUrls: ['alertas.component.css']
})
export class AlertasComponent {

  constructor(public alertService: AlertasService) { }

  closeAlert(alert: IAlert) {

    this.alertService.closeAlert(alert);
  }
}


