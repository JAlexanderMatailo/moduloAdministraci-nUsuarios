using dbPrueba;

namespace moduloAdministraciónUsuarios.Service
{
    public interface IUsuario
    {
        List<Departamento> GetAllDepartamentos();
        List<Cargo> GetAllCargo();
    }
}
