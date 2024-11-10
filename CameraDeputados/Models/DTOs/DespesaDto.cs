namespace CameraDeputados.Models.DTOs
{
    public record DespesaDto(
        string DataEmissao,
        string Fornecedor,
        string ValorLiquido,
        string UrlNotaFiscal);
}
