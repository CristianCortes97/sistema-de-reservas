import { Component } from '@angular/core';
import { ReservaService } from '../reserva.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-crear-reserva',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './crear-reserva.component.html',
  styleUrl: './crear-reserva.component.css'
})
export class CrearReservaComponent {
  reserva = { nombre: '' };

  constructor(private reservaService: ReservaService, private router: Router) { }

  createReserva(): void {
    this.reservaService.createReserva(this.reserva).subscribe(() => {
      this.router.navigate(['/reservas']);
    });
  }
}
