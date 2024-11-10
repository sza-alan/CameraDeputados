using CameraDeputados.Models;
using CameraDeputados.Models.DTOs;
using System.Globalization;

namespace CameraDeputados.Mappers
{
    public static class DespesaMapper
    {
        public static DespesaPorEstadoDto MapearParaDto(this List<Despesa> despesas)
        {
            var totalDespesas = despesas.Sum(x => x.ValorLiquido).ToString("C", new CultureInfo("pt-br"));

            return despesas.Select(d => new DespesaPorEstadoDto(totalDespesas)).FirstOrDefault();
        }
    }
}
