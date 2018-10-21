namespace PortalNotasFaculdades.Models
{
    using PortalNotasFaculdades.Areas.AdminPortal.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsuariosFaculdades
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(120, ErrorMessage = "Preecha com no M�ximo 120 caracteres!")]
        [Display(Name = "Nome de Usu�rio")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(320, ErrorMessage = "Preecha com no M�ximo 320 caracteres!")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Preencha com um E-Mail V�lido!")]
        [Index("EmailUsuarioFaculdade", IsUnique = true)]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(320, ErrorMessage = "Preecha com no M�ximo 320 caracteres!")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string SenhaUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(280, ErrorMessage = "Preecha com no M�ximo 280 caracteres!")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Data �ltimo Acesso")]
        public DateTime? DataUltimoAcesso { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(100, ErrorMessage = "Preecha com no M�ximo 100 caracteres!")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        public int? FaculdadeId { get; set; }

        public int? FaculdadeEmail { get; set; }

        [Required(ErrorMessage = "O campo {0} � obrigat�rio!")]
        [StringLength(300)]
        public string EmailFaculdade { get; set; }

        public virtual Faculdades Faculdades { get; set; }
    }
}
