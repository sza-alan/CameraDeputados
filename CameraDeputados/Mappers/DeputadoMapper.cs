using CameraDeputados.Models;
using CameraDeputados.Models.DTOs;
using System.Globalization;

namespace CameraDeputados.Mappers
{
    public static class DeputadoMapper
    {
        public static List<DeputadoDto> MapearParaListaDto(this List<Deputado> deputados)
        {
            return deputados.Select(dep => new DeputadoDto(
                dep.Id, 
                dep.Nome, 
                dep.Uf, 
                dep.CPF, 
                dep.Partido))
                .ToList();
        }

        public static DeputadoComDespesaDto MapearParaDto(this Deputado deputado)
        {
            var despesasDto = deputado.Despesas
                .OrderByDescending(x => x.ValorLiquido)
                .Select(despesa => new DespesaDto(
                        despesa.DataEmissao, 
                        despesa.Fornecedor,
                        despesa.ValorLiquido.ToString("C", new CultureInfo("pt-br")), 
                        despesa.UrlNotaFiscal)).ToList();

            var totalDespesas = deputado.Despesas.Sum(x => x.ValorLiquido).ToString("C", new CultureInfo("pt-br"));

            return new DeputadoComDespesaDto(totalDespesas, deputado.Id, deputado.Nome, deputado.Uf, deputado.CPF, deputado.Partido, despesasDto);
        }
    }
}
