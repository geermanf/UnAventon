import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'registrarse', component: RegistrarseComponent},
    { path: '', redirectTo: 'home', pathMatch: 'full'},

    // otherwise redirect to home
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

// , canActivate: [AuthGuard]

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
