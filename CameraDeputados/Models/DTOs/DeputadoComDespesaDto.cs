namespace CameraDeputados.Models.DTOs
{
    public record DeputadoComDespesaDto(
        string TotalDespesas,
        int Id,
        string Nome,
        string Uf,
        string CPF,
        string Partido,
        List<DespesaDto> Despesas);
}
