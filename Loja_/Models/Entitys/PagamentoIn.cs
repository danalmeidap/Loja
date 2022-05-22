using System.ComponentModel.DataAnnotations;


namespace Loja_.Models.Entitys
{
    public class PagamentoIn
    {
        [Required]
        public int CompraId { get; set; }

        public CartaoCreditoIn Cartao { get; set; }
    }
}
