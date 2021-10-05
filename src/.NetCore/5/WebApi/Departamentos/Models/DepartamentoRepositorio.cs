using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDepartamentos.Models
{
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        public DepartamentoRepositorio(ApplicationDbContext context) : base(context)
        {
            //Do Something
        }

        public void Go(Departamento departamento)
        {
            throw new NotImplementedException();
        }
    }
}