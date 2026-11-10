
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalMatricula_ValverdeAmanda.Models;

namespace ProyectoFinalMatricula_ValverdeAmanda.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Carrera> Carreras { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Docente> Docentes { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Matricula>()
                .HasOne(m => m.Estudiante)
                .WithMany()
                .HasForeignKey(m => m.EstudianteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany()
                .HasForeignKey(m => m.CursoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
