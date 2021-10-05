using System;
using System.Collections.Generic;

namespace WebApiEmpleados.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public int? DepartamentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}