using CameraDeputados.Infra.Repositories.Interfaces;
using CameraDeputados.Models;
using Microsoft.EntityFrameworkCore;

namespace CameraDeputados.Infra.Repositories
{
    public class DeputadoRepostory : IDeputadoRepository
    {
        private readonly ApplicationDbContext _context;

        public DeputadoRepostory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Deputado>> ListarDeputadosPorEstadoAsync(string uf)
        {
            return await _context.Deputados.Where(d => d.Uf.Equals(uf.ToUpper()))
                .ToListAsync();
        }

        public async Task<Deputado?> ObterDeputadoComDespesaPorEstado(string uf, int idDeputado)
        {
            return await _context.Deputados
                .Include(d => d.Despesas)
                .FirstOrDefaultAsync(d => d.Id == idDeputado);
        }

        public async Task CarregarBaseDeputado(List<Deputado> deputados)
        {
            await _context.Deputados.AddRangeAsync(deputados);
            await _context.SaveChangesAsync();
        }

        public async Task CarregarBaseDespesas(List<Despesa> despesas)
        {
            await _context.Despesas.AddRangeAsync(despesas);
            await _context.SaveChangesAsync();
        }
    }
}
