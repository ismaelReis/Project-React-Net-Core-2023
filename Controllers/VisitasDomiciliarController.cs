using Microsoft.AspNetCore.Mvc;
using SidimEsus.Controllers.ReactAdminController;
using SidimEsus.Models;
using SidimEsus.Repos;

namespace SidimEsus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitasDomiciliarController : ReactAdminController<VisitaDomiciliar>
    {
        public VisitasDomiciliarController(AppDatabase context) : base(context)
        {
            _table = context.VisitasDomiciliar;
        }
    }
}
