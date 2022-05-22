using System;
namespace Loja_.Models.Entitys
{
    public class ProdutoOut
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public double ValorProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public DateTime DataDeAdicao { get; set; }
    }
}
