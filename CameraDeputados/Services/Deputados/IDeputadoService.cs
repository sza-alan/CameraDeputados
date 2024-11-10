using CameraDeputados.Models.DTOs;

namespace CameraDeputados.Services.Deputados
{
    public interface IDeputadoService
    {
        public Task<List<DeputadoDto>> ListarDeputadosPorEstadoAsync(string uf);
        public Task<DeputadoComDespesaDto> ObterDeputadoComDespesasAsync(string uf, int idDeputado);
        public Task<DespesaPorEstadoDto> ObterDespesaPorEstadoAsync(string uf);
    }
}
