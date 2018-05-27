import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AlertasService {
  public alerts: Array<IAlert> = [];
  public lenght: Observable<number> = Observable.create(this.alerts.length);

  constructor() { }

  addAlert(type: string, message: string) {
    const alert = {
      id: this.alerts.length,
      type: type,
      message: message,
    };
    this.alerts.push(alert);
    setTimeout(() => this.closeAlert(alert), 4000);
  }

  closeAllAlerts() {
    this.alerts = []
  }

  closeAlert(alert: IAlert) {
    if (this.alerts.indexOf(alert) !== -1) {
      const index: number = this.alerts.indexOf(alert);
      this.alerts.splice(index, 1);
    }

  }

  getAlerts() {
    return this.alerts;
  }

  getLength() {
    return this.lenght;
  }

}

export interface IAlert {
  id: number;
  type: string;
  message: string;
}
