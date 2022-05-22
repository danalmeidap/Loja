using Loja_.Models.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Loja_.Controllers
{
        [ApiController]
        [Route("api/pagamentos/compras")]
        public class PagamentoControler : ControllerBase
        {
            private PagamentoRepository _pagamentoRepository;
            public PagamentoControler(PagamentoRepository pagamentoRepository)
            {
                _pagamentoRepository = pagamentoRepository;
            }
            [HttpPost]
            public IActionResult Add(PagamentoIn pagamentoIn)
            {
                _pagamentoRepository.Add(pagamentoIn);
                return Ok("Pagamento Cadastrado");
            }
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_pagamentoRepository.Get());
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var pagamentoSelecionado = _pagamentoRepository.GetById(id);
                return pagamentoSelecionado != null
                    ? Ok(pagamentoSelecionado)
                    : BadRequest("Erro ao buscar cartao");
            }
        }
}
