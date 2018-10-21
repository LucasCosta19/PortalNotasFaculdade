namespace PortalNotasFaculdades.Areas.AdminPortal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Faculdades")]
    public partial class Faculdades
    {
        [Key]
        public int FaculdadeId { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(300)]
        [Display(Name = "Nome Faculdade")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(30)]
        [Display(Name = "Tipo Pessoa")]
        public string TipoPessoa { get; set; }

        [StringLength(20)]
        [Display(Name = "CPF")]        
        public string Cpf { get; set; }

        [StringLength(30)]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(16)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(260)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Preencha com um E-Mail Válido!")]
        [Index("EmailFaculdade", IsUnique = true)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(30)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(120)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(120)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(9)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        public virtual ICollection<Faculdades> Faculdade { get; set; }
    }
}