using CameraDeputados.Infra.Repositories.Interfaces;
using CameraDeputados.Mappers;
using CameraDeputados.Models.DTOs;
using System.Globalization;

namespace CameraDeputados.Services.Deputados
{
    public class DeputadoService : IDeputadoService
    {
        private readonly IDeputadoRepository _deputadoRepository;
        private readonly IDespesaRepository _despesaRepository;

        public DeputadoService(IDeputadoRepository deputadoRepository, IDespesaRepository despesaRepository)
        {
            _deputadoRepository = deputadoRepository;
            _despesaRepository = despesaRepository;
        }

        public async Task<List<DeputadoDto>> ListarDeputadosPorEstadoAsync(string uf)
        {
            var deputados = await _deputadoRepository.ListarDeputadosPorEstadoAsync(uf);

            return deputados.MapearParaListaDto();
        }

        public async Task<DeputadoComDespesaDto> ObterDeputadoComDespesasAsync(string uf, int idDeputado)
        {
            var deputado = await _deputadoRepository.ObterDeputadoComDespesaPorEstado(uf, idDeputado);

            return deputado is null ? null : deputado.MapearParaDto();
        }

        public async Task<DespesaPorEstadoDto> ObterDespesaPorEstadoAsync(string uf)
        {
            var despesas = await _despesaRepository.ObterTotalDespesasPorEstadoAsync(uf);

            return despesas.MapearParaDto();
        }
    }
}
