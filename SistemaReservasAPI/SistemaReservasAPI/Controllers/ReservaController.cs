using ApiRest.Application;
using ApiRest.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaReservasAPI.DTO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SistemaReservasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IApplication<Reserva> _reservaApplication;

        public ReservaController(IApplication<Reserva> reservaApplication)
        {
            _reservaApplication = reservaApplication;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reservas = _reservaApplication.GetAll();
            var reservasDto = reservas.Select(r => new ReservaDto
            {
                Id = r.ReservaId,
                ClienteId = r.ClienteId,
                ServicioId = r.ServicioId,
                Fecha = r.Fecha,
                Cliente = new ClienteDto
                {
                    Id = r.Cliente?.ClienteId ?? 0,
                    Nombre = r.Cliente?.Nombre
                },
                Servicio = new ServicioDto
                {
                    Id = r.Servicio?.ServicioId ?? 0,
                    Nombre = r.Servicio?.Nombre
                }
            }).ToList();

            return Ok(reservasDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reserva = _reservaApplication.GetById(id);
            if (reserva == null)
            {
                return NotFound();
            }

            // Crear el DTO de la reserva
            var reservaDto = new ReservaDto
            {
                Id = reserva.ReservaId,
                ClienteId = reserva.ClienteId,
                ServicioId = reserva.ServicioId,
                Fecha = reserva.Fecha,
                Cliente = reserva.Cliente != null ? new ClienteDto
                {
                    Id = reserva.Cliente.ClienteId,
                    Nombre = reserva.Cliente.Nombre
                } : new ClienteDto
                {
                    Id = 0,
                    Nombre = null
                },
                Servicio = reserva.Servicio != null ? new ServicioDto
                {
                    Id = reserva.Servicio.ServicioId,
                    Nombre = reserva.Servicio.Nombre
                } : new ServicioDto
                {
                    Id = 0,
                    Nombre = null
                }
            };

            return Ok(reservaDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservaDto reservaDto)
        {
            if (reservaDto == null)
            {
                return BadRequest();
            }

            var reserva = new Reserva
            {
                ClienteId = reservaDto.ClienteId,
                ServicioId = reservaDto.ServicioId,
                Fecha = reservaDto.Fecha
            };

            var result = _reservaApplication.Save(reserva);

            var resultDto = new ReservaDto
            {
                Id = result.ReservaId,
                ClienteId = result.ClienteId,
                ServicioId = result.ServicioId,
                Fecha = result.Fecha,
                Cliente = new ClienteDto
                {
                    Id = result.Cliente?.ClienteId ?? 0,
                    Nombre = result.Cliente?.Nombre
                },
                Servicio = new ServicioDto
                {
                    Id = result.Servicio?.ServicioId ?? 0,
                    Nombre = result.Servicio?.Nombre
                }
            };

            return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReservaDto reservaDto)
        {
            if (reservaDto == null || id != reservaDto.Id)
            {
                return BadRequest();
            }

            var existingReserva = _reservaApplication.GetById(id);
            if (existingReserva == null)
            {
                return NotFound();
            }

            existingReserva.ClienteId = reservaDto.ClienteId;
            existingReserva.ServicioId = reservaDto.ServicioId;
            existingReserva.Fecha = reservaDto.Fecha;

            _reservaApplication.Save(existingReserva);

            var updatedReservaDto = new ReservaDto
            {
                Id = existingReserva.ReservaId,
                ClienteId = existingReserva.ClienteId,
                ServicioId = existingReserva.ServicioId,
                Fecha = existingReserva.Fecha,
                Cliente = new ClienteDto
                {
                    Id = existingReserva.Cliente?.ClienteId ?? 0,
                    Nombre = existingReserva.Cliente?.Nombre
                },
                Servicio = new ServicioDto
                {
                    Id = existingReserva.Servicio?.ServicioId ?? 0,
                    Nombre = existingReserva.Servicio?.Nombre
                }
            };

            return Ok(updatedReservaDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reservaApplication.DeleteById(id);
            return NoContent();
        }
    }

}
