using System.ComponentModel.DataAnnotations;

namespace Dia11.Models
{
    public class Unidad
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar La Marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage ="Debe ingresar el Modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Debe ingresar el año")]
        public int Año { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Kilometraje")]
        public int Kilometraje { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Precio")]
        public double Precio { get; set; }
    }
}
