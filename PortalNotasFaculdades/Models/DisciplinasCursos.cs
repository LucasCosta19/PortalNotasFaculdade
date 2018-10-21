namespace PortalNotasFaculdades.Models
{
    using PortalNotasFaculdades.Areas.AdminPortal.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DisciplinasCursos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DisciplinasCursos()
        {
            NotasAlunos = new HashSet<NotasAlunos>();
            Professores = new HashSet<Professores>();
            Professores1 = new HashSet<Professores>();
            Professores2 = new HashSet<Professores>();
            Professores3 = new HashSet<Professores>();
            Professores4 = new HashSet<Professores>();
            Professores5 = new HashSet<Professores>();
        }

        [Key]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(280, ErrorMessage = "Preecha com no Máximo 280 caracteres!")]
        [Display(Name = "Disciplina")]
        public string NomeDisciplina { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "Preecha com no Máximo 100 caracteres!")]
        [Display(Name = "Semestre")]
        public string SemestreDisciplina { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(10, ErrorMessage = "Preecha com no Máximo 10 caracteres!")]
        [Display(Name = "Horas Aulas")]
        public string HorasAulasDadas { get; set; }

        public int? FaculdadeId { get; set; }

        [StringLength(300)]
        public string EmailFaculdade { get; set; }

        public virtual Cursos Cursos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotasAlunos> NotasAlunos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores5 { get; set; }

        public virtual Faculdades Faculdades { get; set; }
    }
}
