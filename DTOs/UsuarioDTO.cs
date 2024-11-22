using GlobalSolutionsET.Models;

namespace GlobalSolutionsET.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

    }
}
