using dbPrueba;
using moduloAdministracionUsuarios.ViewModel;

namespace moduloAdministracionUsuarios.Service
{
    public interface IUsuario
    {
        List<Departamento> GetAllDepartamentos();
        List<Cargo> GetAllCargo();

        bool registrarUsuario(UserVM userVM);
        List<UserVM> GetAllUsuarios();
        bool actualizarUser(UserVM user);
        bool eliminarUser(string nombreUsuario);
    }
}
