import { Routes } from '@angular/router';
import { CrearReservaComponent } from './crear-reserva/crear-reserva.component';
import { EditarReservaComponent } from './editar-reserva/editar-reserva.component';
import { ListaReservaComponent } from './lista-reserva/lista-reserva.component';

export const routes: Routes = [
  { path: 'nueva-reserva', component: CrearReservaComponent },
  { path: 'editar-reserva/:id', component: EditarReservaComponent },
  { path: 'reservas', component: ListaReservaComponent },
  { path: '', redirectTo: '/reservas', pathMatch: 'full' }
];
