using dbPrueba;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace moduloAdministraciónUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private pruebaContext _context;
        public UsuariosController(pruebaContext context)
        {
            _context = context;
        }
        [HttpGet("Departamentos")]
        public IEnumerable<Departamento> GetCargos() => _context.Departamentos.ToList();

        [HttpGet("Cargos")]
        public IEnumerable<Cargo> getCargos() => _context.Cargos.ToList();
    }
}
