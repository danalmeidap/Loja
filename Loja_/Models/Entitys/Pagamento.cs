using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_.Models.Entitys
{
    public class Pagamento
    {
        [Key()]
        public int Id { get; set; }

        [ForeignKey("Compra")]
        public int CompraId { get; set; }
        public virtual Compra compra { get; set; }

        public double Valor { get; set; }

        public DateTime DataPagamento { get; set; }

        public bool Aprovado { get; set; } = false;

    }
}
