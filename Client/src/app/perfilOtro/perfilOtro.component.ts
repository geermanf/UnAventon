import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from '../guards/auth.guard';
import { UserService } from '../services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertasService } from '../alertas/alertas.service';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { ViajeService } from '../services/viaje.service';

@Component({
  selector: 'app-perfilOtro',
  templateUrl: './perfilOtro.component.html',
  styleUrls: ['./perfilOtro.component.css', '../../assets/css/modal.css']
})
export class PerfilOtroComponent implements OnInit {
  @ViewChild('perfilTabs') staticTabs: TabsetComponent;
  urlFoto: any;
  usuario: any = {};
  viajes: any[] = [];


  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private viajeService: ViajeService,
    public authGuard: AuthGuard) { }



  ngOnInit() {
    const tabId = this.route.snapshot.queryParams['tabId'] === undefined ? 0 : this.route.snapshot.queryParams['tabId'];
    const id = parseInt(this.route.snapshot.queryParams['id'], 10);
    this.staticTabs.tabs[tabId].active = true;

    this.usuario = this.userService.getById(id).subscribe(
      data => {
        this.usuario = data;
        this.getViajes();
        return data;
      },
      error => {
        return error;
      });
  }
  getViajes() {
    this.viajes = [];
    this.viajeService.getViajesRealizados(this.usuario.id)
      .map(res => Object.keys(res).map(index => this.viajes.push(res[index])))
      .subscribe();
  }

}