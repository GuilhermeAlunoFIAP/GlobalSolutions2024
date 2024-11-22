using GlobalSolutionsET.Models;
using GlobalSolutionsET.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolutionsET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public AnuncioController(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }


        /// <summary>
        /// Retorna todos os anúncios cadastrados
        /// </summary>
        /// <returns>Lista dos anúncios</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Anuncio>> ListarAnuncios()
        {
            return Ok(_anuncioRepository.ListarAnuncios());
        }


        /// <summary>
        /// Busca os dados de um Anúncio pelo id
        /// </summary>
        /// <param name="id">Id do Anúncio</param>
        /// <returns>Dados do Anúncio</returns>
        [HttpGet("{id}")]
        public ActionResult<Anuncio> BuscarAnuncioPorId(int id)
        {
            var anuncio = _anuncioRepository.BuscarAnuncioPorId(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return Ok(anuncio);
        }


        /// <summary>
        /// Inseri novos dados de um anúncio no banco de dados
        /// </summary>
        /// <param name="anuncio">Dados do anúncio</param>
        /// <returns>Retorna os dados inseridos com sucesso</returns>
        [HttpPost]
        public IActionResult InserirAnuncio([FromBody] Anuncio anuncio)
        {
            _anuncioRepository.Inserir(anuncio);
            return CreatedAtAction(nameof(BuscarAnuncioPorId), new { id = anuncio.Id }, anuncio);
        }


        /// <summary>
        /// Atualiza os dados de um anúncio pelo seu ID
        /// </summary>
        /// <param name="id">Id do Anúncio a ser atualizado</param>
        /// <param name="anuncioAtualizado">Dados do anúncio atualizado</param>
        /// <returns>Confirmação da Atualização</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarAnuncio(int id, [FromBody] Anuncio anuncioAtualizado)
        {
            var anuncio = _anuncioRepository.BuscarAnuncioPorId(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            anuncio.Status = anuncioAtualizado.Status;
            anuncio.DataAnuncio = anuncioAtualizado.DataAnuncio;
            anuncio.Energia = anuncioAtualizado.Energia;
            anuncio.Valor = anuncioAtualizado.Valor;
            anuncio.UsuarioId = anuncioAtualizado.UsuarioId;
            anuncio.CompradorId = anuncioAtualizado.CompradorId;

            _anuncioRepository.Atualizar(anuncio);
            return NoContent();
        }


        /// <summary>
        /// Deleta os dados de um anúncio pelo seu ID
        /// </summary>
        /// <param name="id">Id do Anúncio a ser deletado</param>
        /// <returns>Confirmação da exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarAnuncio(int id)
        {
            var anuncio = _anuncioRepository.BuscarAnuncioPorId(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            _anuncioRepository.Deletar(id);
            return NoContent();
        }
    }
}
