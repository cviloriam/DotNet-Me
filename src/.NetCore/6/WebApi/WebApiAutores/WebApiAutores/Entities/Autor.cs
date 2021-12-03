using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validations;

namespace WebApiAutores.Entities
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe tener más de {1} carácteres")]
        //[PrimeraLetraMayuscula]
        public string Name { get; set; }
        //[Range(18, 90)]
        //[NotMapped]
        //public int Edad { get; set; }
        //[CreditCard]
        //public string TarjetaDeCredito { get; set; }
        //[Url]
        //[NotMapped]
        //public string Web { get; set; }
        public List<Libro> Libros { get; set; }

        //public int Menor { get; set; }
        //public int Mayor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name)) 
            {
                var primeraLetra = Name[0].ToString();

                if (!primeraLetra.Equals(primeraLetra.ToUpper()))
                    yield return new ValidationResult("La primera letra debe ser mayúscula", new string[] { nameof(Name) });
            }

            //if (Menor > Mayor)
            //    yield return new ValidationResult("El Valor del número menor no puede ser más grande que el número mayor.", new string[] { nameof(Menor) });
        }
    }
}