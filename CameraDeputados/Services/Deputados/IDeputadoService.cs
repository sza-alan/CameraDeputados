using CameraDeputados.Models.DTOs;

namespace CameraDeputados.Services.Deputados
{
    public interface IDeputadoService
    {
        Task<List<DeputadoDto>> ListarDeputadosPorEstadoAsync(string uf);
    }
}
