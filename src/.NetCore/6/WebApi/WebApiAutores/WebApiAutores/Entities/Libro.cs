using WebApiAutores.Validations;

namespace WebApiAutores.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        [PrimeraLetraMayuscula]
        public string Title { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}