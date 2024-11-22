using GlobalSolutionsET.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionsET.Persistence
{
    public class FIAPDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {

        }
    }
}
