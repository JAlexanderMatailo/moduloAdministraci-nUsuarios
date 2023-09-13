using dbPrueba;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moduloAdministraciónUsuarios.Service;
using moduloAdministraciónUsuarios.ViewModel;

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

        #region endpoit Usuario
        [HttpPost("RegistrarUsuario")]
        public IActionResult RegistrarUsuario(UserVM usuario)
        {
            var result = _usuarioService.registrarUsuario(usuario);
            return new JsonResult(result);
        }

        [HttpGet("GetAllUsuarios")]
        public IActionResult GetAllUsuarios()
        {
            var result = _usuarioService.GetAllUsuarios();
            return new JsonResult(result);
        }

        [HttpPost("ActualizarUsuario")]
        public IActionResult ActualizarUsuario(UserVM usuario)
        {
            var result = _usuarioService.actualizarUser(usuario);
            return new JsonResult(result);
        }

        [HttpPost("EliminacionLogicaUsers")]
        public IActionResult EliminacionLogicaUsers(string user)
        {
            var result = _usuarioService.eliminarUser(user);
            return new JsonResult(result);
        }
        #endregion

    }
}
