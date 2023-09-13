using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbPrueba
{
    public class Cargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCargos { get; set; }

        public string codigoCargo { get; set; }
        public string nombreCargo { get; set; }
        public bool activo { get; set; }
        public int idUsuarioCreacion { get; set; }
    }
}
