import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { AuthGuard } from './guards/auth.guard';
import { PerfilComponent } from './perfil/perfil.component';
import { EditarperfilComponent } from './editarperfil/editarperfil.component';
import { CambiarcontraComponent } from './cambiarcontra/cambiarcontra.component';
import { RegistrarvehiculoComponent } from './registrarvehiculo/registrarvehiculo.component';


const routes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'registrarse', component: RegistrarseComponent},
    { path: 'perfil', component: PerfilComponent},
    { path: 'editarperfil', component: EditarperfilComponent},
    { path: 'cambiarcontra', component: CambiarcontraComponent},
    { path: 'registrarvehiculo', component: RegistrarvehiculoComponent},
    { path: '', redirectTo: 'home', pathMatch: 'full'},

    // otherwise redirect to home
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

//  , canActivate: [AuthGuard]

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
