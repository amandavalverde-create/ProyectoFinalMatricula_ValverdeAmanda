
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalMatricula_ValverdeAmanda.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "La identificación es obligatoria")]
        [StringLength(20)]
        public string Identificacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Phone]
        public string Telefono { get; set; } = string.Empty;

        public int CarreraId { get; set; }

        public Carrera? Carrera { get; set; }
    }
}
