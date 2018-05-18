import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';

import { AppComponent } from './app.component';
import { IniciarSesionComponent } from './iniciarSesion/iniciarSesion.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { IniciarSesionModalComponent } from './iniciarSesionModal/iniciarSesionModal.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    IniciarSesionComponent,
    NavbarComponent,
    FooterComponent,
    RegistrarseComponent,
    IniciarSesionModalComponent,
  ],
  entryComponents: [IniciarSesionModalComponent],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    FormsModule,
    RouterModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }