using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDepartamentos.Models;

namespace ApiDepartamentosTests.Mock
{
    public class DepartamentoRepositorioMock : IRepositorio<T>, IDepartamentoRepositorio
    {
        public void Actualizar(T entidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public T ConsultarXId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Crear(T entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public void Go(Departamento departamento)
        {
            throw new NotImplementedException();
        }
    }
}