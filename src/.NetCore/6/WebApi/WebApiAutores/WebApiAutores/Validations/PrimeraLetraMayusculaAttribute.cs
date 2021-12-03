using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.Validations
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) 
            {
                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()[0].ToString();

            if (!primeraLetra.Equals(primeraLetra.ToUpper()))
                return new ValidationResult("La primera letra debe ser mayúscula");

            return ValidationResult.Success;
        }
    }
}