namespace PortalNotasFaculdades.Models
{
    using PortalNotasFaculdades.Areas.AdminPortal.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Professores
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "E-Mail")]
        [StringLength(320, ErrorMessage = "Preencha com no máximo 320 caracteres!!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Preencha com um E-Mail Válido!")]
        [Index("EmailProfessor", IsUnique = true)]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "CPF")]
        [StringLength(14, ErrorMessage = "Preencha com no máximo 14 caracteres!!")]
        [Index("CpfProfessor", IsUnique = true)]
        public string CpfUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome Completo")]
        [StringLength(280, ErrorMessage = "Preencha com no máximo 280 caracteres!!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Situação")]
        [StringLength(1, ErrorMessage = "Preencha com no máximo 1 caracteres!!")]
        public string SituacaoUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Curso Ministrado")]
        public int CursoIdUm { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Disciplina Ministrada")]
        public int DisciplinaUm { get; set; }

        [Display(Name = "Disciplina Ministrada")]
        public int? DisciplinaDois { get; set; }

        [Display(Name = "Disciplina Ministrada")]
        public int? DisciplinaTres { get; set; }

        [Display(Name = "Curso Ministrada")]
        public int? CursoIdDois { get; set; }

        [Display(Name = "Disciplina Ministrada")]
        public int? DisciplinaQuatro { get; set; }

        [Display(Name = "Disciplina Ministrada")]
        public int? DisciplinaCinco { get; set; }

        [Display(Name = "Disciplina Ministrada")]
        public int? DisciplinaSeis { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Data de Cadastro")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data Último Acesso")]
        [Column(TypeName = "date")]
        public DateTime? DataUltimoAcesso { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "Preencha com no máximo 100 caracteres!!")]
        public string Tipo { get; set; }

        public int? FaculdadeId { get; set; }

        [StringLength(300)]
        public string EmailFaculdade { get; set; }

        public virtual Cursos Cursos { get; set; }

        public virtual Cursos Cursos1 { get; set; }

        public virtual DisciplinasCursos DisciplinasCursos { get; set; }

        public virtual DisciplinasCursos DisciplinasCursos1 { get; set; }

        public virtual DisciplinasCursos DisciplinasCursos2 { get; set; }

        public virtual DisciplinasCursos DisciplinasCursos3 { get; set; }

        public virtual DisciplinasCursos DisciplinasCursos4 { get; set; }

        public virtual DisciplinasCursos DisciplinasCursos5 { get; set; }

        public virtual Faculdades Faculdades { get; set; }
    }
}
