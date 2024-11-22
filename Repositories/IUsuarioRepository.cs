using GlobalSolutionsET.Models;

namespace GlobalSolutionsET.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> ListarUsuarios(); 
        Usuario BuscarUsuarioPorId(int id); 
        void Inserir(Usuario usuario); 
        void Atualizar(Usuario usuario); 
        void Deletar(int id); 
        Usuario Login(string email, string senha);
    }
}
