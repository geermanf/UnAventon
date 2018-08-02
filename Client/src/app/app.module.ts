import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { HttpClientModule } from '@angular/common/http';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { NgxSmartModalModule } from 'ngx-smart-modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GooglePlaceModule } from 'ngx-google-places-autocomplete';
import { DatePipe } from '@angular/common';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

// Import Services
import { UserService } from './services/user.service';
import { ViajeService } from './services/viaje.service';
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
import { ContenedorViajeComponent } from './viajes/contenedorViaje/contenedorViaje.component';
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
import { EditarVehiculosComponent } from './perfil/editarVehiculos/editarVehiculos.component';
import { CrearViajeComponent } from './crearViaje/crearViaje.component';
import { VerViajesComponent } from './viajes/verViajes/verViajes.component';
import { VerViajes2Component } from './viajes/verViajes2/verViajes2.component';
import { DetalleViajeComponent } from './viajes/detalleViaje/detalleViaje.component';
import {PerfilOtroComponent } from './perfilOtro/perfilOtro.component';
import {ContenedorViajePerfilComponent } from './perfil/contenedorViaje/contenedorViajePerfil.component';
import {ModificarViajeComponent } from './modificarViaje/modificarViaje.component';
import {ContenedorComentarioComponent } from './perfil/contenedorComentario/contenedorComentario.component';
import {PendientesComponent } from './pendientes/pendientes.component';
import {SobreNosotrosComponent } from './sobreNosotros/sobreNosotros.component';
import {ContactoAdminComponent } from './contactoAdmin/contactoAdmin.component';
import {PregFrecuentesComponent} from './pregFrecuentes/pregFrecuentes.component';
import {ContenedorPuntuacionComponent} from './pendientes/contenedorPuntuacion/contenedorPuntuacion.component';
import {ContenedorPreguntaComponent} from './pendientes/contenedorPregunta/contenedorPregunta.component';
import {ContenedorPagoComponent} from './pendientes/contenedorPago/contenedorPago.component';
import {ContenedorReputacionComponent } from './perfil/contenedorReputacion/contenedorReputacion.component';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NgbModule.forRoot(),
    BsDatepickerModule.forRoot(),
    FormsModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    NgxSmartModalModule.forRoot(),
    TabsModule.forRoot(),
    GooglePlaceModule
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
    EditarVehiculosComponent,
    CrearViajeComponent,
    VerViajesComponent,
    VerViajes2Component,
    DetalleViajeComponent,
    PerfilOtroComponent,
    ContenedorViajePerfilComponent,
    ModificarViajeComponent,
    ContenedorComentarioComponent,
    PendientesComponent,
    SobreNosotrosComponent,
    ContactoAdminComponent,
    PregFrecuentesComponent,
    ContenedorPuntuacionComponent,
    ContenedorPreguntaComponent,
    ContenedorPagoComponent,
    ContenedorReputacionComponent
],
  exports: [
    ContenedorViajeComponent,
    BuscadorComponent,
    BorrarCuentaComponent,
    CambiarContraseniaComponent,
    EditarPerfilComponent,
    ContenedorVehiculoComponent,
    FormularioVehiculosComponent,
    FormularioTarjetasComponent,
    EditarVehiculosComponent,
    ContenedorViajePerfilComponent,
    ContenedorComentarioComponent,
    PendientesComponent,
    SobreNosotrosComponent,
    ContactoAdminComponent,
    PregFrecuentesComponent,
    ContenedorPreguntaComponent,
    ContenedorPagoComponent,
    ContenedorReputacionComponent
  ],
  providers: [
    DatePipe,
    AuthGuard,
    AuthenticationService,
    UserService,
    ViajeService,
    VehiculoService,
    TarjetaService,
    AlertasService,
    NgxSmartModalService,
    TipoTarjetaService,
    BancoService,
  ],
  entryComponents: [IniciarSesionModalComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
