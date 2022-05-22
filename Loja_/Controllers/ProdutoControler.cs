using Microsoft.AspNetCore.Mvc;
using Loja_.Models.Entitys;

namespace Loja_.Controllers
{
    [ApiController]
    [Route("api/produto")]

    public class ProdutoControler : ControllerBase
    {
        private ProdutoRepository _produtoRepository;
        public ProdutoControler(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtoRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produtoSelecionado = _produtoRepository.GetById(id);
            return produtoSelecionado != null
                ? Ok(produtoSelecionado)
                : BadRequest("Erro ao buscar produto");
        }

        [HttpPost]
        public IActionResult AddProduto(ProdutoIn produto)
        {
            _produtoRepository.Add(produto);
            return Ok("Produto Cadastrado");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduto(int id, ProdutoIn produto)
        {
            _produtoRepository.Update(id, produto);
            return Ok("Produto Cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            _produtoRepository.Delete(id);
            return NoContent();
        }
    }
}
