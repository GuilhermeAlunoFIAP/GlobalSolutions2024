using GlobalSolutionsET.Models;
using GlobalSolutionsET.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionsET.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly FIAPDbContext _context;

        public AnuncioRepository(FIAPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Anuncio> ListarAnuncios()
        {
            return _context.Anuncios.Include(a => a.Usuario)
                                    .Include(a => a.Comprador)
                                    .ToList();
        }

        public Anuncio BuscarAnuncioPorId(int id)
        {
            return _context.Anuncios.Include(a => a.Usuario)
                                    .Include(a => a.Comprador)
                                    .FirstOrDefault(a => a.Id == id);
        }

        public void Inserir(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            _context.SaveChanges();
        }

        public void Atualizar(Anuncio anuncio)
        {
            _context.Anuncios.Update(anuncio);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var anuncio = _context.Anuncios.Find(id);
            if (anuncio != null)
            {
                _context.Anuncios.Remove(anuncio);
                _context.SaveChanges();
            }
        }
    }
}
