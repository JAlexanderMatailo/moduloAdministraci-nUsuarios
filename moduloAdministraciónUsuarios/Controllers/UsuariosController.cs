using dbPrueba;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moduloAdministraciónUsuarios.Service;

namespace moduloAdministraciónUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuario _usuarioService;
        public UsuariosController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet("GetAllDepartamentos")]
        public IActionResult GetAllDepartamentos()
        {
            var result = _usuarioService.GetAllDepartamentos();
            return new JsonResult(result);
        }

        [HttpGet("GetAllCargo")]
        public IActionResult GetAllCargo() { 
            var result = _usuarioService.GetAllCargo();
            return new JsonResult(result);
        }

    }
}
