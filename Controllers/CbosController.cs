using Microsoft.AspNetCore.Mvc;
using SidimEsus.Controllers.ReactAdminController;
using SidimEsus.Models;
using SidimEsus.Repos;

namespace SidimEsus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CbosController : ReactAdminController<Cbo>
    {
        public CbosController(AppDatabase context) : base(context)
        {
            _table = context.Cbos;
        }
    }
}
