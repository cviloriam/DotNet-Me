using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEmpleados.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string NombreTipoDoc { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}