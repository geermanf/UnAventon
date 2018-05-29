import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {
  @ViewChild('editarTabs') staticTabs: TabsetComponent;

  constructor(
    private route: ActivatedRoute) { }

  ngOnInit() {
    const tabId = this.route.snapshot.queryParams['tabId'] !== undefined ? this.route.snapshot.queryParams['tabId'] : 0 ;
    this.staticTabs.tabs[tabId].active = true;
  }

}
