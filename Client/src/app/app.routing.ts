import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { AuthGuard } from './guards/auth.guard';
import { PerfilComponent } from './perfil/perfil.component';
import { EditarComponent } from './editar/editar.component';
import { CrearViajeComponent } from './crearViaje/crearViaje.component';
import { VerViajesComponent } from './viajes/verViajes/verViajes.component';
import { DetalleViajeComponent } from './viajes/detalleViaje/detalleViaje.component';
import {PerfilOtroComponent } from './perfilOtro/perfilOtro.component';


const routes: Routes = [

    // PUBLICAS
    { path: 'home', component: HomeComponent},
    { path: 'registrarse', component: RegistrarseComponent},
    { path: 'verViajes', component: VerViajesComponent},
    { path: 'verPerfilOtro', component: PerfilOtroComponent},
    // USUARIOS LOGUEADOS
    { path: 'perfil', component: PerfilComponent, canActivate: [AuthGuard]},
    { path: 'editar', component: EditarComponent, canActivate: [AuthGuard]},
    { path: 'crearViaje', component: CrearViajeComponent, canActivate: [AuthGuard]},
    { path: 'detalleViaje', component: DetalleViajeComponent, canActivate: [AuthGuard]},



    // INCORRECTO O VACIO
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
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
