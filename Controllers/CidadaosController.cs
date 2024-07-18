using Microsoft.AspNetCore.Mvc;
using SidimEsus.Repos;
using System.Linq;

namespace SidimEsus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadaosController : ControllerBase
    {
        private readonly AppDatabase _context;

        public CidadaosController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Cidadaos.Take(100));
        }
    }
}
