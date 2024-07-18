using Microsoft.AspNetCore.Mvc;
using SidimEsus.Controllers.ReactAdminController;
using SidimEsus.Models;
using SidimEsus.Repos;

namespace SidimEsus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ReactAdminController<Funcionario>
    {
        public FuncionariosController(AppDatabase context) : base(context)
        {
            _table = context.Funcionarios;
        }
    }
}
