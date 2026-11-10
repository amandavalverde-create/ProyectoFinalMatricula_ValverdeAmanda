
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalMatricula_ValverdeAmanda.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }

        [Required(ErrorMessage = "El nombre de la carrera es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public bool Estado { get; set; } = true;
    }
}
