using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_.Models.Entitys
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public double ValorProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public DateTime DataDeAdicao { get; set; }
    }
}
