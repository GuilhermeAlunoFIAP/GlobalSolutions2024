using GlobalSolutionsET.Models;

namespace GlobalSolutionsET.Repositories
{
    public interface IPagamentoRepository
    {
        IEnumerable<Pagamento> ListarPagamentos(); 
        Pagamento BuscarPagamentoPorId(int id); 
        void Inserir(Pagamento pagamento); 
        void Atualizar(Pagamento pagamento); 
        void Deletar(int id);
    }
}
