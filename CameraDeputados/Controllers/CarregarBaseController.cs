using CameraDeputados.Services.BaseDados;
using Microsoft.AspNetCore.Mvc;

namespace CameraDeputados.Controllers
{
    [ApiController]
    [Route("carregar-base-dados")]
    public class CarregarBaseController : Controller
    {
        private readonly ICarregarBaseService _carregarBaseService;

        public CarregarBaseController(ICarregarBaseService carregarBaseService)
        {
            _carregarBaseService = carregarBaseService;
        }

        [HttpPost]
        public async Task<IActionResult> PostBaseDados(IFormFile file, string uf)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo CSV invalido.");
            }

            var tempPath = Path.Combine(Path.GetTempPath(), file.FileName);

            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await _carregarBaseService.CarregarBaseDados(tempPath, uf);

            return Ok("Basse carregada com sucesso");
        }
    }
}
