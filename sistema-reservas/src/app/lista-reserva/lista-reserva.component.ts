import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../reserva.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-reserva',
  standalone: true,
  templateUrl: './lista-reserva.component.html',
  styleUrls: ['./lista-reserva.component.css']
})
export class ListaReservaComponent implements OnInit {
  reservas: any[] = [];

  constructor(private reservaService: ReservaService, private router: Router) { }

  ngOnInit(): void {
    this.loadReservas();
  }

  loadReservas(): void {
    this.reservaService.getReservas().subscribe(data => {
      this.reservas = data;
    });
  }

  deleteReserva(id: number): void {
    if (confirm('¿Estás seguro de que deseas eliminar esta reserva?')) {
      this.reservaService.deleteReserva(id).subscribe(() => {
        this.loadReservas(); // Recargar la lista después de eliminar
      });
    }
  }
}
