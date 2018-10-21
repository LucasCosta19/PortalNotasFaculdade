namespace PortalNotasFaculdades.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cursos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursos()
        {
            Alunos = new HashSet<Alunos>();
            Professores = new HashSet<Professores>();
            Professores1 = new HashSet<Professores>();
            DisciplinasCursos = new HashSet<DisciplinasCursos>();
        }

        [Key]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(16, ErrorMessage = "Preencha com no M�ximo 16 caracteres!")]
        [Display(Name = "N�mero de Semestres")]
        public string SemestresQuant { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(180, ErrorMessage = "Preencha com no M�ximo 180 caracteres!")]
        [Display(Name = "Nome Curso")]
        public string NomeCurso { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(10, ErrorMessage = "Preencha com no M�ximo 10 caracteres!")]
        [Display(Name = "Horas Aulas")]
        public string HorasAulas { get; set; }

        public int? FaculdadeId { get; set; }

        [StringLength(300)]
        public string EmailFaculdade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos> Alunos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professores> Professores1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisciplinasCursos> DisciplinasCursos { get; set; }
    }
}
