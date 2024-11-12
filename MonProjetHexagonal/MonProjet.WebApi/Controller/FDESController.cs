using Microsoft.AspNetCore.Mvc;
using MonProjetHexagonal.Application;
using System.Threading.Tasks;

namespace MonProjetHexagonal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDESController : ControllerBase
    {
        private readonly IFDESService _fdesService;

        public FDESController(IFDESService fdesService)
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
