import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TabsetComponent, TabDirective } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {
  @ViewChild('editarTabs') staticTabs: TabsetComponent;

  constructor(
    private route: ActivatedRoute) { }

  show(data: TabDirective): void {
    this.staticTabs.tabs.forEach(e => e.customClass = 'no-visible');
    setTimeout(() => data.customClass = 'visible', 100);
  }

  ngOnInit() {
    const tabId = this.route.snapshot.queryParams['tabId'] !== undefined ? this.route.snapshot.queryParams['tabId'] : 0;
    this.show(this.staticTabs.tabs[tabId]);
    this.staticTabs.tabs[tabId].active = true;
  }

}
