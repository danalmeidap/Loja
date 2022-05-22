using System;

namespace Loja_.Models.Entitys
{
    public class CompraOut
    {
        public int Id { get; set; }

        public string Produto { get; set; }


        public int QuantidadeComprada { get; set; }

        public DateTime DataDeCompra { get; set; }

        public CartaoCredito cartaoCredito { get; set; }

    }
}
