using System.ComponentModel.DataAnnotations;

namespace Dia11.Models
{
    public class Consecionaria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Imagen { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
