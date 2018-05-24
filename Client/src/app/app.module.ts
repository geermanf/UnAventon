import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { NgxSmartModalModule } from 'ngx-smart-modal';

// Import Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { IniciarSesionModalComponent } from './iniciarSesion/iniciarSesionModal/iniciarSesionModal.component';
import { ContenedorViajeComponent } from './viaje/contenedorViaje.component';
import { BuscadorComponent } from './buscador/buscador.component';
// Import Services
import { UserService } from './services/user.service';
import { AuthGuard } from './guards/auth.guard';
import { JwtInterceptor } from './iniciarSesion/login/helpers/jwt.interceptor';
import { AuthenticationService } from './services/authentication.service';
import { fakeBackendProvider } from './iniciarSesion/login/helpers/fake-backend';
import { PerfilComponent } from './perfil/perfil.component';
import { EditarperfilComponent } from './editarperfil/editarperfil.component';
import { CambiarcontraComponent } from './cambiarcontra/cambiarcontra.component';




@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NgbModule.forRoot(),
    FormsModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    NgxSmartModalModule.forRoot(),
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    RegistrarseComponent,
    IniciarSesionModalComponent,
    ContenedorViajeComponent,
    BuscadorComponent,
    PerfilComponent,
    EditarperfilComponent,
    CambiarcontraComponent,
],
  exports: [
    ContenedorViajeComponent,
    BuscadorComponent
  ],
  providers: [
    AuthGuard,
    AuthenticationService,
    UserService,
    {
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptor,
        multi: true
    },
    NgxSmartModalService,

    // provider used to create fake backend
    fakeBackendProvider
  ],
  entryComponents: [IniciarSesionModalComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
