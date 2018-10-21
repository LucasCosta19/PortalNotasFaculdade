namespace PortalNotasFaculdades.Models
{
    using PortalNotasFaculdades.Areas.AdminPortal.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NotasAlunos
    {
        [Key]
        public int NotaId { get; set; }

        [Display(Name = "Nome Aluno")]
        public int UsuarioId { get; set; }

        [Display(Name = "Disciplina")]
        public int DisciplinaNota { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [MaxLength(4, ErrorMessage = "Preencha com no m�ximo 4 caracteres!!")]
        [Display(Name = "Trabalho N1")]
        public string TrabalhoNotaN1 { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [MaxLength(4, ErrorMessage = "Preencha com no m�ximo 4 caracteres!!")]
        [Display(Name = "Trabalho N2")]
        public string TrabalhoNotaN2 { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [MaxLength(4, ErrorMessage = "Preencha com no m�ximo 4 caracteres!!")]
        [Display(Name = "Trabalho N3")]
        public string TrabalhoNotaN3 { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [MaxLength(4, ErrorMessage = "Preencha com no m�ximo 4 caracteres!!")]
        [Display(Name = "Prova N1")]
        public string NotaProvaN1 { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [MaxLength(4, ErrorMessage = "Preencha com no m�ximo 4 caracteres!!")]
        [Display(Name = "Prova N2")]
        public string NotaProvaN2 { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [MaxLength(4, ErrorMessage = "Preencha com no m�ximo 4 caracteres!!")]
        [Display(Name = "Prova N3")]
        public string NotaProvaN3 { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Display(Name = "M�dia Final")]
        public string MediaFinal { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Display(Name = "Aulas Dadas")]
        public int AulasDadas { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Display(Name = "Faltas")]
        public int QuantidadeFaltas { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Display(Name = "Percentual de Faltas")]
        public string PercentualFaltas { get; set; }

        [Display(Name = "Exame Final")]
        public string ExameFinal { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Display(Name = "Situa��o")]
        public string SituacaoAluno { get; set; }

        public int? FaculdadeId { get; set; }

        [StringLength(300)]
        public string EmailFaculdade { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }

        [Display(Name = "Data do Lan�amento")]
        public DateTime DataInsercao { get; set; }

        public int? DisciplinasCursos_DisciplinaId { get; set; }

        public virtual Alunos Alunos { get; set; }

        public virtual DisciplinasCursos DisciplinasCursos { get; set; }

        public virtual Faculdades Faculdades { get; set; }
    }
}
