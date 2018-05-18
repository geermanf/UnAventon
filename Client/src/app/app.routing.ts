import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { IniciarSesionComponent } from './iniciarSesion/iniciarSesion.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';

const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'login', component: IniciarSesionComponent },
    { path: 'registrarse', component: RegistrarseComponent },
    { path: '', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
