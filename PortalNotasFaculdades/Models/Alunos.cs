namespace PortalNotasFaculdades.Models
{
    using PortalNotasFaculdades.Areas.AdminPortal.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Alunos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alunos()
        {
            NotasAlunos = new HashSet<NotasAlunos>();
        }

        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(320, ErrorMessage = "Preencha com no M�ximo 320 caracteres!")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Preencha com um E-Mail V�lido!")]      
        [Index("EmailAluno", IsUnique = true)]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(16, ErrorMessage = "Preencha com no M�ximo 16 caracteres!")]
        [Display(Name = "CPF")]
        [Index("CpfAluno", IsUnique = true)]
        public string CpfUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(280, ErrorMessage = "Preencha com no M�ximo 280 caracteres!")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(180, ErrorMessage = "Preencha com no M�ximo 180 caracteres!")]
        [Display(Name = "Endere�o")]
        public string EnderecoUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(80, ErrorMessage = "Preencha com no M�ximo 80 caracteres!")]
        [Display(Name = "Cidade")]
        public string CidadeUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(80, ErrorMessage = "Preencha com no M�ximo 80 caracteres!")]
        [Display(Name = "Estado")]
        public string EstadoUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(14, ErrorMessage = "Preencha com no M�ximo 14 caracteres!")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(1, ErrorMessage = "Preencha com no M�ximo 1 caracteres!")]
        [Display(Name = "Situa��o")]
        public string SituacaoUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Column(TypeName = "date")]
        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data �ltimo Acesso")]
        [DataType(DataType.Date)]
        public DateTime? DataUltimoAcesso { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(100, ErrorMessage = "Preencha com no M�ximo 100 caracteres!")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [StringLength(300)]
        public string EmailFaculdade { get; set; }

        public int? FaculdadeId { get; set; }

        public virtual Cursos Cursos { get; set; }

        public virtual Faculdades Faculdades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotasAlunos> NotasAlunos { get; set; }
    }
}
