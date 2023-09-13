using dbPrueba;
using moduloAdministraciónUsuarios.ViewModel;

namespace moduloAdministraciónUsuarios.Service
{
    public class UsuarioService : IUsuario
    {
        pruebaContext _context;
        public UsuarioService(pruebaContext context)
        {
            _context = context;
        }

        #region Departamentos
        public List<Departamento> GetAllDepartamentos()
        {
            List<Departamento> listaDepartamento = new List<Departamento>();
            var departamento = _context.Departamentos.ToList();
            foreach (var department in departamento)
            {
                Departamento departamentos = new Departamento
                {
                    IdDepartamento = department.IdDepartamento,
                    nombreDepartamento = department.nombreDepartamento
                };
                listaDepartamento.Add(departamentos);
            };
            return listaDepartamento;
        }
        #endregion

        #region Cargos
        public List<Cargo> GetAllCargo()
        {
            List<Cargo> listaCargos = new List<Cargo>();
            var cargo= _context.Cargos.ToList();
            foreach(var cargos  in cargo)
            {
                Cargo Ucargos = new Cargo
                {
                    IdCargos = cargos.IdCargos,
                    nombreCargo = cargos.nombreCargo
                };
                listaCargos.Add(Ucargos);
            }
            return listaCargos;
        }
        #endregion

        #region Usuarios
        public bool registrarUsuario(UserVM userVM)
        {
            var existe = _context.Users.Where(x => x.usaurio == userVM.usaurio).Any();
            bool registrado = false;

            return registrado;
        }
        #endregion
    }
}
