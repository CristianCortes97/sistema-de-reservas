using System;

namespace SistemaReservasAPI.DTO
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteDto Cliente { get; set; }
        public ServicioDto Servicio { get; set; }
    }

}
