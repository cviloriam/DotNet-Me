using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDepartamentos.Models
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad, new()
    {
        public readonly ApplicationDbContext context;

        public Repositorio(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Actualizar(T entidad)
        {
            context.Entry(entidad).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<T> ConsultarTodos()
        {
            return context.Set<T>();
        }

        public T ConsultarXId(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Crear(T entidad)
        {
            context.Entry(entidad).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var entidad = new T() { Id = id };
            context.Entry(entidad).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}