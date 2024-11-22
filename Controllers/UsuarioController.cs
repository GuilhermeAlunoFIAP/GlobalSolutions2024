using GlobalSolutionsET.DTOs;
using GlobalSolutionsET.Models;
using GlobalSolutionsET.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolutionsET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        /// <summary>
        /// Retorna todos os usuarios cadastrados
        /// </summary>
        /// <returns>Lista de Usuários</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> ListarUsuarios()
        {
            var usuarios = _usuarioRepository.ListarUsuarios();
            var usuarioDtos = usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                EnderecoId = usuario.EnderecoId,
                Endereco = usuario.Endereco
            });

            return Ok(usuarioDtos);
        }


        /// <summary>
        /// Busca os dados de um Usuário pelo id
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>Dados do Usuário</returns>
        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> BuscarUsuarioPorId(int id)
        {
            var usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                EnderecoId = usuario.EnderecoId,
                Endereco = usuario.Endereco
            };

            return Ok(usuarioDto);
        }


        /// <summary>
        /// Inseri um novo usário no banco de dados
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        /// <returns>Dados do usuário inseridos</returns>
        [HttpPost]
        public IActionResult InserirUsuario([FromBody] Usuario usuario)
        {
            _usuarioRepository.Inserir(usuario);
            return CreatedAtAction(nameof(BuscarUsuarioPorId), new { id = usuario.Id }, usuario);
        }


        /// <summary>
        /// Atualiza os dados do usuário já cadastrado atravé do seu ID
        /// </summary>
        /// <param name="id">Id do Usuário a ser atualizado</param>
        /// <param name="usuarioDTO">Dados do usuário atualizado</param>
        /// <returns>Confirmação da atualização</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nome = usuarioDTO.Nome;
            usuario.DataNascimento = usuarioDTO.DataNascimento;
            usuario.Email = usuarioDTO.Email;
            usuario.Telefone = usuarioDTO.Telefone;
            usuario.EnderecoId = usuarioDTO.EnderecoId;
            usuario.Endereco = usuarioDTO.Endereco;

            _usuarioRepository.Atualizar(usuario);
            return NoContent();
        }


        /// <summary>
        /// Deleta os dados de um usuário pelo seu ID
        /// </summary>
        /// <param name="id">Id do Usuário a ser deletado</param>
        /// <returns>Confirmação da exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            var usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioRepository.Deletar(id);
            return NoContent();
        }


        /// <summary>
        /// Realiza o login do usuário com base em seu email e senha
        /// </summary>
        /// <param name="loginDto">Email e Senha do usuário</param>
        /// <returns>Retorna caso o login seja bem sucedido.</returns>
        [HttpPost("login")]
        public ActionResult<UsuarioDTO> Login([FromBody] LoginUsuarioDTO loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var usuario = _usuarioRepository.Login(loginDto.Email, loginDto.Senha);
            if (usuario == null)
            {
                return Unauthorized();
            }

            var usuarioDto = new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                EnderecoId = usuario.EnderecoId,
                Endereco = usuario.Endereco
            };

            return Ok(usuarioDto);
        }
    }
}
