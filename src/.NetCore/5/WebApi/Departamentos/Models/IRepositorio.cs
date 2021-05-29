using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDepartamentos.Models
{
    public interface IRepositorio<T>
    {
        void Crear(T entidad);

        T ConsultarXId(int Id);

        void Actualizar(T entidad);

        void Eliminar(int Id);

        IEnumerable<T> ConsultarTodos();
    }
}
