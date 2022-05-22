using System;
using System.ComponentModel.DataAnnotations;

namespace Loja_.Models.Entitys
{
    public class CartaoCreditoIn
    {
        [Required, StringLength(100)]
        public string TitularCartao { get; set; }

        [Required, CreditCard]
        public string NumeroCartao { get; set; }

        [Required]
        public string DataExpiracao { get; set; }

        [Required]
        public string BandeiraCartao { get; set; }


        [Required, StringLength(3)]
        public string CodigoSeguranca { get; set; }
    }
}
