using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRest.Entities.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
