namespace PortalNotasFaculdades.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PortalNotasFaculdades.Areas.AdminPortal.Models;
    using PortalNotasFaculdades.Migrations;

    public partial class PortalContext : DbContext
    {
        public PortalContext(): base("name=PortalContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PortalContext, Configuration>());
        }

        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<DisciplinasCursos> DisciplinasCursos { get; set; }
        public virtual DbSet<Faculdades> Faculdades { get; set; }
        public virtual DbSet<NotasAlunos> NotasAlunos { get; set; }
        public virtual DbSet<Professores> Professores { get; set; }
        public virtual DbSet<UsuariosAdmin> UsuariosAdmin { get; set; }
        public virtual DbSet<UsuariosFaculdades> UsuariosFaculdades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alunos>()
                .HasMany(e => e.NotasAlunos)
                .WithRequired(e => e.Alunos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cursos>()
                .HasMany(e => e.Professores)
                .WithOptional(e => e.Cursos)
                .HasForeignKey(e => e.CursoIdDois);

            modelBuilder.Entity<Cursos>()
                .HasMany(e => e.Professores1)
                .WithRequired(e => e.Cursos1)
                .HasForeignKey(e => e.CursoIdUm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cursos>()
                .HasMany(e => e.DisciplinasCursos)
                .WithRequired(e => e.Cursos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DisciplinasCursos>()
                .HasMany(e => e.NotasAlunos)
                .WithRequired(e => e.DisciplinasCursos)
                .HasForeignKey(e => e.DisciplinaNota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DisciplinasCursos>()
                .HasMany(e => e.Professores)
                .WithOptional(e => e.DisciplinasCursos)
                .HasForeignKey(e => e.DisciplinaCinco);

            modelBuilder.Entity<DisciplinasCursos>()
                .HasMany(e => e.Professores1)
                .WithOptional(e => e.DisciplinasCursos1)
                .HasForeignKey(e => e.DisciplinaDois);

            modelBuilder.Entity<DisciplinasCursos>()
                .HasMany(e => e.Professores2)
                .WithOptional(e => e.DisciplinasCursos2)
                .HasForeignKey(e => e.DisciplinaQuatro);

            modelBuilder.Entity<DisciplinasCursos>()
                .HasMany(e => e.Professores3)
                .WithOptional(e => e.DisciplinasCursos3)
                .HasForeignKey(e => e.DisciplinaSeis);

            modelBuilder.Entity<DisciplinasCursos>()
                .HasMany(e => e.Professores4)
                .WithOptional(e => e.DisciplinasCursos4)
                .HasForeignKey(e => e.DisciplinaTres);

            modelBuilder.Entity<DisciplinasCursos>()
                .HasMany(e => e.Professores5)
                .WithRequired(e => e.DisciplinasCursos5)
                .HasForeignKey(e => e.DisciplinaUm)
                .WillCascadeOnDelete(false);

           /* modelBuilder.Entity<Faculdades>()
                .HasMany(e => e.Alunos)
                .WithOptional(e => e.Faculdades)
                .WillCascadeOnDelete();*/
        }
    }
}
