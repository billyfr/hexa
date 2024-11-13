using Microsoft.AspNetCore.Mvc;
using MonProjetHexagonal.Application.Services;

namespace MonProjetHexagonal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDESController : ControllerBase
    {
        private readonly FDESService _fdesService;

        public FDESController(FDESService fdesService)
        {
            _fdesService = fdesService;
        }

        [HttpGet("GetFDES")]
        public async Task<IActionResult> GetFDES([FromQuery] string catalogVersion, [FromQuery] string schemaElementId, [FromQuery] string projectVersionId)
        {
            // Appeler le service pour récupérer les données basées sur les paramètres
            var fdesData = await _fdesService.GetFDESDataAsync(catalogVersion, schemaElementId, projectVersionId);

            if (fdesData == null)
            {
                return NotFound(new { Message = "FDES not found" });
            }

            return Ok(fdesData);
        }
    }
}
