using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbPrueba
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDepartamento { get; set; }

        public string codigoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public bool activo { get; set; }
        public int idUsuarioCreacion { get; set; }
    }
}
