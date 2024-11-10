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
    }
}
