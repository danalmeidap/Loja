using Microsoft.AspNetCore.Mvc;
using Loja_.Models.Entitys;

namespace Loja_.Controllers
{
    [ApiController]
    [Route("api/cartoes")]
    public class CartaoCreditoController : ControllerBase
    {
        private CartaoCreditoRepository _cartaoCreditoRepository;
        public CartaoCreditoController(CartaoCreditoRepository cartaoCreditoRepository)
        {
            _cartaoCreditoRepository = cartaoCreditoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cartaoCreditoRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cartaoSelecionado = _cartaoCreditoRepository.GetById(id);
            return cartaoSelecionado != null
                ? Ok(cartaoSelecionado)
                : BadRequest("Erro ao buscar cartao");
        }

        [HttpPost]
        public IActionResult Add(CartaoCreditoIn cartaoIn)
        {
            _cartaoCreditoRepository.Add(cartaoIn);
            return Ok("Cartao Cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CartaoCreditoIn cartaoIn)
        {
            _cartaoCreditoRepository.Update(id, cartaoIn);
            return Ok("Cartao cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cartaoCreditoRepository.Delete(id);
            return NoContent();
        }

    }
}
