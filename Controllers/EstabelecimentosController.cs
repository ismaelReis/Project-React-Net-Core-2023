using Microsoft.AspNetCore.Mvc;
using SidimEsus.Controllers.ReactAdminController;
using SidimEsus.Models;
using SidimEsus.Repos;

namespace SidimEsus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentosController : ReactAdminController<Estabelecimento>
    {
        public EstabelecimentosController(AppDatabase context) : base(context)
        {
            _table = context.Estabelecimentos;
        }
    }
}
