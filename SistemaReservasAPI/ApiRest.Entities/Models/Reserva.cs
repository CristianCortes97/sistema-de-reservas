using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRest.Entities.Models
{
    public partial class Reserva
    {
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
