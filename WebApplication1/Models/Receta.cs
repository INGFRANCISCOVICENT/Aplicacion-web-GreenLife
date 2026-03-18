using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Receta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string? Titulo { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        public string? Ingredientes { get; set; }

        // En minutos
        public int TiempoPreparacion { get; set; }

        [StringLength(50)]
        public string? Categoria { get; set; }
    }
}
