using Microsoft.AspNetCore.Mvc;
using Loja_.Models.Entitys;

namespace Loja_.Controllers
{
    [ApiController]
    [Route("api/compras")]

    public class CompraControler : ControllerBase
    {
        private CompraRepository _compraRepository;
        public CompraControler(CompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_compraRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var compraSelecionada = _compraRepository.GetById(id);
            return compraSelecionada != null
                ? Ok(compraSelecionada)
                : BadRequest("Erro ao buscar Ordem de Compra");
        }

        [HttpPost]
        public IActionResult AddProduto(CompraIn compra)
        {
            _compraRepository.Add(compra);
            return Ok("Compra Cadastrada");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _compraRepository.Delete(id);
            return NoContent();
        }
    }
}
