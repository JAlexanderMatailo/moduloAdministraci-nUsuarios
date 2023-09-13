using Microsoft.EntityFrameworkCore;

namespace dbPrueba
{
    public class pruebaContext : DbContext
    {
        public pruebaContext(DbContextOptions<pruebaContext> options)
            : base(options) 
        { 

        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<User> Users { get; set; }

        
    }
}