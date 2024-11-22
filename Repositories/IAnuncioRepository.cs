using GlobalSolutionsET.Models;

namespace GlobalSolutionsET.Repositories
{
    public interface IAnuncioRepository
    {
        IEnumerable<Anuncio> ListarAnuncios(); 
        Anuncio BuscarAnuncioPorId(int id); 
        void Inserir(Anuncio anuncio); 
        void Atualizar(Anuncio anuncio); 
        void Deletar(int id);
    }
}
