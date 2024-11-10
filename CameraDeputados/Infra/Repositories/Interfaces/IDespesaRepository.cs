using CameraDeputados.Models;

namespace CameraDeputados.Infra.Repositories.Interfaces
{
    public interface IDespesaRepository
    {
        Task<List<Despesa>> ObterTotalDespesasPorEstadoAsync(string uf);
    }
}
