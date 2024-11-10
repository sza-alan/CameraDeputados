using CameraDeputados.Services.Deputados;
using Microsoft.AspNetCore.Mvc;

namespace CameraDeputados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeputadoController : ControllerBase
    {
        private readonly IDeputadoService _deputadoService;

        public DeputadoController(IDeputadoService deputadoService)
        {
            _deputadoService = deputadoService;
        }

        [HttpGet("{uf}/deputados")]
        public async Task<IActionResult> ListarDeputadosPorEstado(string uf)
        {
            var deputados = await _deputadoService.ListarDeputadosPorEstadoAsync(uf);

            return Ok(new { data = deputados.ToList() });
        }

        [HttpGet("estados/{uf}/deputados/{deputadoId}/despesas")]
        public async Task<IActionResult> ListarDespesasPorDeputado(string uf, int deputadoId)
        {
            var despesas = await _deputadoService.ObterDeputadoComDespesasAsync(uf, deputadoId);
            if (despesas is null)
            {
                return NotFound(new
                {
                    success = false, status = 400,
                    message = $"Nenhuma despesa encontrada para o deputado com ID: {deputadoId}"
                });
            }

            return Ok(new { data = despesas });
        }

        [HttpGet("estados/{uf}/despesas")]
        public async Task<IActionResult> ListarDespesasPorEstado(string uf)
        {
            var despesas = await _deputadoService.ObterDespesaPorEstadoAsync(uf);
            if (despesas is null)
            {
                return NotFound(new
                {
                    success = false, status = 400,
                    message = $"Nenhuma despesa encontrada para o estado."
                });
            }

            return Ok(new { data = despesas });
        }
    }
}
