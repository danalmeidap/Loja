using System;
using System.ComponentModel.DataAnnotations;

namespace Loja_.Models.Entitys
{
    public class ProdutoIn
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string NomeProduto { get; set; }
        [Required]
        [Range(0, 10000)]
        public double ValorProduto { get; set; }
        [Required]
        [Range(0, 100)]
        public int QuantidadeProduto { get; set; }
    }
}
