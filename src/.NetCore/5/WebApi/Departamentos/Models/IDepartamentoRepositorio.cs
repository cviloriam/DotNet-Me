using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDepartamentos.Models
{
    interface IDepartamentoRepositorio : IRepositorio<Departamento>
    {
        void Go(Departamento departamento);
    }
}