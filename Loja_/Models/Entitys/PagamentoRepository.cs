using System;
using System.Collections.Generic;
using System.Linq;
using Loja_.Context;

namespace Loja_.Models.Entitys
{
    public class PagamentoRepository
    {
        private LojaContext _context;

        public PagamentoRepository(LojaContext context)
        {
            _context = context;
        }
        public IEnumerable<PagamentoOut> Get()
        {
            return _context.pagamentos.Select(pagamento => new PagamentoOut
            {
                Id = pagamento.Id,
                Valor = pagamento.Valor,
                DataPagamento = DateTime.Now,
                Aprovado = GeraResultado(pagamento)
            });
        }

        public PagamentoOut GetById(int id)
        {
            var pagamento = _context.pagamentos.FirstOrDefault(x => x.Id == id);
            return GetPagamentoOut(pagamento);
        }

        public PagamentoOut Add(PagamentoIn pagamentoIn)
        {
            var produtoRepository = new ProdutoRepository(_context);
            int produtoId = _context.Compras.Find(pagamentoIn.CompraId).ProdutoId;
            var produto = _context.Produtos.First(x => x.Id == produtoId);
            int quantidadeComprada = _context.Compras.Find(pagamentoIn.CompraId).QuantidadeComprada;
            int quantidadeProduto = produto.QuantidadeProduto;
            double valor = _context.Compras.Find(pagamentoIn.CompraId).Produto.ValorProduto;
            if (quantidadeComprada > 0 && quantidadeComprada < quantidadeProduto)
            {
                quantidadeProduto = quantidadeProduto - quantidadeComprada;
                valor = quantidadeComprada * valor;
            }
            produto.QuantidadeProduto = quantidadeProduto;
            var pagamento = new Pagamento
            {
                CompraId = pagamentoIn.CompraId,
                Valor = valor,
                DataPagamento = DateTime.Now
            };
            _context.Produtos.Update(produto);
            _context.pagamentos.Add(pagamento);
            _context.SaveChanges();
            return GetPagamentoOut(pagamento);
        }

        static bool GeraResultado(Pagamento pagamento)
        {
            if (pagamento.Valor > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public PagamentoOut GetPagamentoOut(Pagamento pagamento)
        {

            return new PagamentoOut
            {
                Id = pagamento.Id,
                Valor = pagamento.Valor,
                DataPagamento = DateTime.Now,
                Aprovado = GeraResultado(pagamento)
            };
        }
    }
}
