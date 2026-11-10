
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalMatricula_ValverdeAmanda.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10")]
        public int Creditos { get; set; }

        public int CarreraId { get; set; }

        public Carrera? Carrera { get; set; }

        public bool Estado { get; set; } = true;
    }
}
