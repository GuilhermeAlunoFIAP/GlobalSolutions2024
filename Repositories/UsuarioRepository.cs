using GlobalSolutionsET.Models;
using GlobalSolutionsET.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionsET.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FIAPDbContext _context;

        public UsuarioRepository(FIAPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return _context.Usuarios.Include(u => u.Endereco).ToList();
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return _context.Usuarios.Include(u => u.Endereco)
                                    .FirstOrDefault(u => u.Id == id);
        }

        public void Inserir(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios
                           .FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
