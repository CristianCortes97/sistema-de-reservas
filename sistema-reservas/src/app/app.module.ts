import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { EditarReservaComponent } from './editar-reserva/editar-reserva.component';
import { ListaReservaComponent } from './lista-reserva/lista-reserva.component';
import { AppRoutingModule } from './app.routes';
import { CrearReservaComponent } from './crear-reserva/crear-reserva.component';

@NgModule({
  declarations: [
    AppComponent,
    ListaReservaComponent,
    CrearReservaComponent,
    EditarReservaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
