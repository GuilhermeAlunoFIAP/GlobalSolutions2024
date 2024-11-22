using GlobalSolutionsET.Models;
using GlobalSolutionsET.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionsET.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly FIAPDbContext _context;

        public PagamentoRepository(FIAPDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pagamento> ListarPagamentos()
        {
            return _context.Pagamentos.Include(p => p.Usuario)
                                      .Include(p => p.Anuncio)
                                      .ToList();
        }

        public Pagamento BuscarPagamentoPorId(int id)
        {
            return _context.Pagamentos.Include(p => p.Usuario)
                                      .Include(p => p.Anuncio)
                                      .FirstOrDefault(p => p.Id == id);
        }

        public void Inserir(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        public void Atualizar(Pagamento pagamento)
        {
            _context.Pagamentos.Update(pagamento);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var pagamento = _context.Pagamentos.Find(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
                _context.SaveChanges();
            }
        }
    }
}
