using Microsoft.AspNetCore.Mvc;
using SidimEsus.Controllers.ReactAdminController;
using SidimEsus.Models;
using SidimEsus.Repos;

namespace SidimEsus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadaosController : ReactAdminController<Cidadao>
    {
        public CidadaosController(AppDatabase context) : base(context)
        {
            _table = context.Cidadaos;
        }
    }
}
