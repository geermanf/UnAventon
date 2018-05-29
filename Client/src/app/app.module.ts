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
import { TabsModule } from 'ngx-bootstrap/tabs';

// Import Services
import { UserService } from './services/user.service';
import { VehiculoService } from './services/vehiculo.service';
import { TarjetaService } from './services/tarjeta.service';
import { AuthGuard } from './guards/auth.guard';
import { AuthenticationService } from './services/authentication.service';
import { AlertasService } from './alertas/alertas.service';
import { TipoTarjetaService } from './services/tipoTarjeta.service';
import { BancoService } from './services/banco.service';

// Import Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { RegistrarseComponent } from './registrarse/registrarse.component';
import { IniciarSesionModalComponent } from './iniciarSesion/iniciarSesionModal/iniciarSesionModal.component';
import { ContenedorViajeComponent } from './viaje/contenedorViaje.component';
import { BuscadorComponent } from './buscador/buscador.component';
import { PerfilComponent } from './perfil/perfil.component';
import { AlertasComponent } from './alertas/alertas.component';
import { EditarComponent } from './editar/editar.component';
import { BorrarCuentaComponent } from './editar/borrarCuenta/borrarCuenta.component';
import { CambiarContraseniaComponent } from './editar/cambiarContrasenia/cambiarContrasenia.component';
import { EditarPerfilComponent } from './editar/editarPerfil/editarPerfil.component';
import { ContenedorVehiculoComponent } from './perfil/contenedorVehiculo/contenedorVehiculo.component';
import { ContenedorTarjetaComponent } from './perfil/contenedorTarjeta/contenedorTarjeta.component';
import { FormularioVehiculosComponent } from './perfil/formularioVehiculos/formularioVehiculos.component';
import { FormularioTarjetasComponent } from './perfil/formularioTarjetas/formularioTarjetas.component';




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
    TabsModule.forRoot()
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
    AlertasComponent,
    EditarComponent,
    BorrarCuentaComponent,
    CambiarContraseniaComponent,
    EditarPerfilComponent,
    ContenedorVehiculoComponent,
    ContenedorTarjetaComponent,
    FormularioVehiculosComponent,
    FormularioTarjetasComponent,

],
  exports: [
    ContenedorViajeComponent,
    BuscadorComponent,
    BorrarCuentaComponent,
    CambiarContraseniaComponent,
    EditarPerfilComponent,
    ContenedorVehiculoComponent,
    FormularioVehiculosComponent,
    FormularioTarjetasComponent
  ],
  providers: [
    AuthGuard,
    AuthenticationService,
    UserService,
    VehiculoService,
    TarjetaService,
    AlertasService,
    NgxSmartModalService,
    TipoTarjetaService,
    BancoService
  ],
  entryComponents: [IniciarSesionModalComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
