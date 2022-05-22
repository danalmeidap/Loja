using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_.Models.Entitys
{
    public class Compra
    {
        [Key()]
        public int Id { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public int QuantidadeComprada { get; set; }

        public DateTime DataDeCompra { get; set; }

        [ForeignKey("CartaoCredito")]
        public int CartaoId { get; set; }
        public virtual CartaoCredito cartaoCredito { get; set; }
    }
}
