using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNotasFaculdades.Areas.Financeiro.Models {
    public class ContasBancarias {
        [Key]
        public int ContaBancariaId { get; set; }

        [Required]
        [StringLength(30)]
        public string NomeBanco { get; set; }

        [Required]
        [StringLength(60)]
        public string NomeProprietario { get; set; }
        
        [StringLength(30)]
        public string NumeroConta { get; set; }
        
        [StringLength(30)]
        public string Agencia { get; set; }

        [Required]
        [StringLength(30)]
        public string SaldoInicial { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DataSaldoInicial { get; set; }

        [Required]
        [StringLength(30)]
        public string SaldoAtual { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DataInsercao { get; set; }
    }
}