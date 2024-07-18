using Microsoft.AspNetCore.Mvc;
using SidimEsus.Repos;
using System.Linq;

namespace SidimEsus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitasDomiciliarController : ControllerBase
    {
        private readonly AppDatabase _context;

        public VisitasDomiciliarController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.VisitasDomiciliar.Take(100));
        }
    }
}
