using Loja_.Context;
using System.Collections.Generic;
using System.Linq;
namespace Loja_.Models.Entitys
{
    public class CartaoCreditoRepository
    {
        private LojaContext _context;
        public CartaoCreditoRepository(LojaContext context)
        {
            _context = context;
        }
        public IEnumerable<CartaoCreditoOut> Get()
        {
            return _context.cartaoCreditos.Select(cartao => new CartaoCreditoOut
            {
                Id = cartao.Id,
                TitularCartao = cartao.TitularCartao,
                NumeroCartao = cartao.NumeroCartao,
                DataExpiracao = cartao.DataExpiracao,
                BandeiraCartao = cartao.BandeiraCartao,
                CodigoSeguranca = cartao.CodigoSeguranca,
            });
        }

        public CartaoCreditoOut GetById(int id)
        {
            var cartao = _context.cartaoCreditos.First(x => x.Id == id);
            return GeraCartaoCreditoOut(cartao);
        }

        public CartaoCreditoOut Add(CartaoCreditoIn cartaoIn)
        {
            var cartao = new CartaoCredito
            {
                TitularCartao = cartaoIn.TitularCartao,
                NumeroCartao = cartaoIn.NumeroCartao,
                DataExpiracao = cartaoIn.DataExpiracao,
                BandeiraCartao = cartaoIn.BandeiraCartao,
                CodigoSeguranca = cartaoIn.CodigoSeguranca,
            };
            _context.cartaoCreditos.Add(cartao);
            _context.SaveChanges();
            return GeraCartaoCreditoOut(cartao);
        }

        public CartaoCreditoOut Update(int id, CartaoCreditoIn cartaoIn)
        {
            var cartao = new CartaoCredito
            {
                Id = id,
                TitularCartao = cartaoIn.TitularCartao,
                NumeroCartao = cartaoIn.NumeroCartao,
                DataExpiracao = cartaoIn.DataExpiracao,
                BandeiraCartao = cartaoIn.BandeiraCartao,
                CodigoSeguranca = cartaoIn.CodigoSeguranca,
            };
            _context.cartaoCreditos.Update(cartao);
            _context.SaveChanges();
            return GeraCartaoCreditoOut(cartao);
        }

        public void Delete(int id)
        {
            var cartao = _context.cartaoCreditos.FirstOrDefault(x => x.Id == id);
            _context.cartaoCreditos.Remove(cartao);
            _context.SaveChanges();
        }

        public CartaoCreditoOut GeraCartaoCreditoOut(CartaoCredito cartao)
        {
            return new CartaoCreditoOut
            {
                Id = cartao.Id,
                TitularCartao = cartao.TitularCartao,
                NumeroCartao = cartao.NumeroCartao,
                DataExpiracao = cartao.DataExpiracao,
                BandeiraCartao = cartao.BandeiraCartao,
                CodigoSeguranca = cartao.CodigoSeguranca,
            };
        }

        public CartaoCredito GeraCartaoCredito(CartaoCredito cartao)
        {
            return new CartaoCredito
            {
                Id = cartao.Id,
                TitularCartao = cartao.TitularCartao,
                NumeroCartao = cartao.NumeroCartao,
                DataExpiracao = cartao.DataExpiracao,
                BandeiraCartao = cartao.BandeiraCartao,
                CodigoSeguranca = cartao.CodigoSeguranca,
            };
        }
    }
}
