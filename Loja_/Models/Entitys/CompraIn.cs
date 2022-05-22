using System;
using System.ComponentModel.DataAnnotations;

namespace Loja_.Models.Entitys
{
    public class CompraIn
    {
        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public int CartaoId { get; set; }

        [Required]
        [Range(0, 100)]
        public int QuantidadeComprada { get; set; }

        public DateTime DataDeCompra { get; set; }
    }
}
