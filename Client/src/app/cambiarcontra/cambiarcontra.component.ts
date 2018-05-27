import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cambiarcontra',
  templateUrl: './cambiarcontra.component.html',
  styleUrls: ['./cambiarcontra.component.css']
})
export class CambiarcontraComponent implements OnInit {
   password: any;
   passwordRepeat: any;

  constructor() { }

  ngOnInit() {
  }
  contraseniasValidas() {
    return (this.password == this.passwordRepeat);
}
}
