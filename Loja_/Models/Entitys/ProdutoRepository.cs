using Loja_.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_.Models.Entitys
{
    public class ProdutoRepository
    {
        private LojaContext _context;
        public ProdutoRepository(LojaContext context)
        {
            _context = context;
        }
        public ProdutoOut GetById(int id)
        {
            var produto = _context.Produtos.First(x => x.Id == id);
            return GeraProdutoOut(produto);
        }

        public IEnumerable<ProdutoOut> Get()
        {
            return _context.Produtos.Select(produto => new ProdutoOut
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                ValorProduto = produto.ValorProduto,
                QuantidadeProduto = produto.QuantidadeProduto,
                DataDeAdicao = DateTime.Now
            });
        }

        public ProdutoOut Add(ProdutoIn produto)
        {
            var prod = new Produto
            {
                NomeProduto = produto.NomeProduto,
                ValorProduto = produto.ValorProduto,
                QuantidadeProduto = produto.QuantidadeProduto,
                DataDeAdicao = DateTime.Now
            };
            _context.Produtos.Add(prod);
            _context.SaveChanges();
            return GeraProdutoOut(prod);

        }

        public ProdutoOut Update(int id, ProdutoIn produto)
        {
            var prod = new Produto
            {
                Id = id,
                NomeProduto = produto.NomeProduto,
                ValorProduto = produto.ValorProduto,
                QuantidadeProduto = produto.QuantidadeProduto,
                DataDeAdicao = DateTime.Now
            };
            _context.Produtos.Update(prod);
            _context.SaveChanges();
            return GeraProdutoOut(prod);
        }

        public void Delete(int id)
        {
            var prod = _context.Produtos.First(x => x.Id == id);
            _context.Produtos.Remove(prod);
            _context.SaveChanges();
        }

        public ProdutoOut GeraProdutoOut(Produto prod)
        {
            return new ProdutoOut
            {
                Id = prod.Id,
                NomeProduto = prod.NomeProduto,
                ValorProduto = prod.ValorProduto,
                QuantidadeProduto = prod.QuantidadeProduto,
                DataDeAdicao = DateTime.Now
            };
        }
    }
}
