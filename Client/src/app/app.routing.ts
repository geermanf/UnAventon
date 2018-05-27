import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { AuthGuard } from './guards/auth.guard';
import { PerfilComponent } from './perfil/perfil.component';
import { RegistrarvehiculoComponent } from './registrarvehiculo/registrarvehiculo.component';
import { EditarComponent } from './editar/editar.component';


const routes: Routes = [

    // PUBLICAS
    { path: 'home', component: HomeComponent},
    { path: 'registrarse', component: RegistrarseComponent},

    // USUARIOS LOGUEADOS
    { path: 'perfil', component: PerfilComponent, canActivate: [AuthGuard]},
    { path: 'editar', component: EditarComponent, canActivate: [AuthGuard]},
    { path: 'registrarvehiculo', component: RegistrarvehiculoComponent, canActivate: [AuthGuard]},

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
