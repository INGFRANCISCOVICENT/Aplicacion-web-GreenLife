using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }
    }
}
