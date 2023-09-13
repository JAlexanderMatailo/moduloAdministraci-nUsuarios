namespace moduloAdministraciónUsuarios.ViewModel
{
    public class UserVM
    {
        public int IdUsers { get; set; }
        public string usuario { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string email { get; set; }
        public bool estado { get; set; }
        public int IdDepartamentos { get; set; }
        public int IdCargos { get; set; }
    }
}
