import { Component } from '@angular/core';
import { ReservaService } from '../reserva.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-editar-reserva',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './editar-reserva.component.html',
  styleUrl: './editar-reserva.component.css'
})
export class EditarReservaComponent {

  reserva: any = { nombre: '' };

  constructor(
    private reservaService: ReservaService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.reservaService.getReservaById(id).subscribe(data => {
      this.reserva = data;
    });
  }

  updateReserva(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.reservaService.updateReserva(id, this.reserva).subscribe(() => {
      this.router.navigate(['/reservas']);
    });
  }
}
