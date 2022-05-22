namespace Loja_.Models.Entitys
{
    public class CartaoCredito
    {
        public int Id { get; set; }

        public string TitularCartao { get; set; }

        public string NumeroCartao { get; set; }

        public string DataExpiracao { get; set; }
        public string BandeiraCartao { get; set; }

        public string CodigoSeguranca { get; set; }

    }
}
