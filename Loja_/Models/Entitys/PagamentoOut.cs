using System;

namespace Loja_.Models.Entitys
{
    public class PagamentoOut
    {
        public int Id { get; set; }
        public Double Valor { get; set; }

        public DateTime DataPagamento { get; set; }

        public bool Aprovado { get; set; }
    }
}
