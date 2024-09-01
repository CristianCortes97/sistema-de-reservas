using ApiRest.Abstractions;
using ApiRest.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Repository
{
    public interface IRepository<T> : ICrud<T>
    {
        // Puedes agregar métodos adicionales específicos para tu repositorio si es necesario.
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SistemaReservasContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SistemaReservasContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IList<T> GetAll()
        {
            if (typeof(T) == typeof(Reserva))
            {
                // Realiza una carga ansiosa de las relaciones Cliente y Servicio para reservas
                return _dbSet.OfType<Reserva>()
                    .Include(r => r.Cliente)
                    .Include(r => r.Servicio)
                    .ToList() as IList<T>;
            }

            // Para otros tipos de entidades, simplemente retorna la lista sin incluir datos relacionados
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            // Utiliza una carga ansiosa si el tipo es Reserva, para incluir relaciones si es necesario
            if (typeof(T) == typeof(Reserva))
            {
                return _dbSet.OfType<Reserva>()
                    .Include(r => r.Cliente)
                    .Include(r => r.Servicio)
                    .SingleOrDefault(e => EF.Property<int>(e, "ReservaId") == id) as T;
            }

            return _dbSet.Find(id);
        }

        public T Save(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Add(entity);
            }
            else
            {
                _dbSet.Update(entity);
            }
            _context.SaveChanges();
            return entity;
        }

        public void DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
