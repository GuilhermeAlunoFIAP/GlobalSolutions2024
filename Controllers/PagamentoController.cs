using GlobalSolutionsET.Models;
using GlobalSolutionsET.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolutionsET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }


        /// <summary>
        /// Retorna todos os dados dos pagamentos no banco de dados
        /// </summary>
        /// <returns>Lista dos Pagamentos</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Pagamento>> ListarPagamentos()
        {
            return Ok(_pagamentoRepository.ListarPagamentos());
        }


        /// <summary>
        /// Busca os dados de um Pagamento pelo ID
        /// </summary>
        /// <param name="id">Id do Pagamento</param>
        /// <returns>Dados do Pagamento</returns>
        [HttpGet("{id}")]
        public ActionResult<Pagamento> BuscarPagamentoPorId(int id)
        {
            var pagamento = _pagamentoRepository.BuscarPagamentoPorId(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return Ok(pagamento);
        }


        /// <summary>
        /// Inseri um novo pagamento no banco de dados 
        /// </summary>
        /// <param name="pagamento">Dados do Pagamento</param>
        /// <returns>Dados do Pagamento inserido</returns>
        [HttpPost]
        public IActionResult InserirPagamento([FromBody] Pagamento pagamento)
        {
            _pagamentoRepository.Inserir(pagamento);
            return CreatedAtAction(nameof(BuscarPagamentoPorId), new { id = pagamento.Id }, pagamento);
        }


        /// <summary>
        /// Atualiza os dados de um pagamento pelo seu ID
        /// </summary>
        /// <param name="id">Id do Pagamento a ser atualizado</param>
        /// <param name="pagamentoAtualizado">Dados do pagamento atualizado</param>
        /// <returns>Confirmação da atualização</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarPagamentos(int id, [FromBody] Pagamento pagamentoAtualizado)
        {
            var pagamento = _pagamentoRepository.BuscarPagamentoPorId(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            pagamento.Valor = pagamentoAtualizado.Valor;
            pagamento.DataPagamento = pagamentoAtualizado.DataPagamento;
            pagamento.TipoPagamento = pagamentoAtualizado.TipoPagamento;
            pagamento.StatusPagamento = pagamentoAtualizado.StatusPagamento;
            pagamento.UsuarioId = pagamentoAtualizado.UsuarioId;
            pagamento.AnuncioId = pagamentoAtualizado.AnuncioId;

            _pagamentoRepository.Atualizar(pagamento);
            return NoContent();
        }


        /// <summary>
        /// Deleta os dados de um pagamento pelo seu ID
        /// </summary>
        /// <param name="id">Id do Pagamento a ser deletado</param>
        /// <returns>Confirmação da exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarPagamento(int id)
        {
            var pagamento = _pagamentoRepository.BuscarPagamentoPorId(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _pagamentoRepository.Deletar(id);
            return NoContent();
        }
    }
}
