using CameraDeputados.Infra.Repositories.Interfaces;
using CameraDeputados.Models;
using Microsoft.EntityFrameworkCore;

namespace CameraDeputados.Infra.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DespesaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Despesa>> ObterTotalDespesasPorEstadoAsync(string uf)
        {
            return await _applicationDbContext.Despesas
                .Where(d => d.Deputado.Uf.Equals(uf.ToUpper()))
                .ToListAsync();
        }
    }
}
