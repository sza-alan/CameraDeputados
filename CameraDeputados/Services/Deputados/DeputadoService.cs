using CameraDeputados.Infra.Repositories.Interfaces;
using CameraDeputados.Models.DTOs;

namespace CameraDeputados.Services.Deputados
{
    public class DeputadoService : IDeputadoService
    {
        private readonly IDeputadoRepository _deputadoRepository;

        public DeputadoService(IDeputadoRepository deputadoRepository)
        {
            _deputadoRepository = deputadoRepository;
        }

        public async Task<List<DeputadoDto>> ListarDeputadosPorEstadoAsync(string uf)
        {
            var deputados = await _deputadoRepository.ListarDeputadosPorEstadoAsync(uf);

            var deputadosDto = deputados.Select(d => new DeputadoDto(d.Id, d.Nome, d.Uf, d.Cpf, d.Partido)).ToList();

            return deputadosDto;
        }
    }
}
