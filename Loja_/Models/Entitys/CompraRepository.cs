using Loja_.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loja_.Models.Entitys
{
    public class CompraRepository
    {
        private LojaContext _context;
        public CompraRepository(LojaContext context)
        {
            _context = context;
        }
        public IEnumerable<CompraOut> Get()
        {
            var cartaoCreditoRepository = new CartaoCreditoRepository(_context);
            return _context.Compras.Select(compra => new CompraOut
            {
                Id = compra.Id,
                Produto = compra.Produto.NomeProduto,
                QuantidadeComprada = compra.QuantidadeComprada,
                DataDeCompra = DateTime.Now,
                cartaoCredito = cartaoCreditoRepository.GeraCartaoCredito(_context.cartaoCreditos.First(x => x.Id == compra.CartaoId))
            });
        }

        public CompraOut GetById(int id)
        {
            var compra = _context.Compras.FirstOrDefault(x => x.Id == id);
            return GeraCompraOut(compra);
        }

        public CompraOut Add(CompraIn compra)
        {
            var comp = new Compra
            {
                ProdutoId = compra.ProdutoId,
                QuantidadeComprada = compra.QuantidadeComprada,
                DataDeCompra = compra.DataDeCompra,
                CartaoId = compra.CartaoId,
            };
            _context.Compras.Add(comp);
            _context.SaveChanges();
            return GeraCompraOut(comp);
        }

        public void Delete(int id)
        {
            var compra = _context.Compras.FirstOrDefault(x => x.Id == id);
            _context.Compras.Remove(compra);
            _context.SaveChanges();
        }

        public CompraOut GeraCompraOut(Compra comp)
        {
            var cartaoCreditoRepository = new CartaoCreditoRepository(_context);
            return new CompraOut
            {
                Id = comp.Id,
                Produto = _context.Produtos.Find(comp.ProdutoId).NomeProduto,
                QuantidadeComprada = comp.QuantidadeComprada,
                DataDeCompra = comp.DataDeCompra,
                cartaoCredito = cartaoCreditoRepository.GeraCartaoCredito(_context.cartaoCreditos.First(x => x.Id == comp.CartaoId))
            };
        }
    }
}
