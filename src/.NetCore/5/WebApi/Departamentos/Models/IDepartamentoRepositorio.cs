using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDepartamentos.Models
{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento>
    {
        void Go(Departamento departamento);
    }
}