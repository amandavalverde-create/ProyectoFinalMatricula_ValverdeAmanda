
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalMatricula_ValverdeAmanda.Models
{
    public class Matricula
    {
        [Key]
        public int MatriculaId { get; set; }

        [Required]
        public int EstudianteId { get; set; }

        public Estudiante? Estudiante { get; set; }

        [Required]
        public int CursoId { get; set; }

        public Curso? Curso { get; set; }

        [Required]
        public DateTime FechaMatricula { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string Estado { get; set; } = "Activa";
    }
}
