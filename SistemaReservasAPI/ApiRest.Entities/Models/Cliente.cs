using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRest.Entities.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
