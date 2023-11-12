using Microsoft.EntityFrameworkCore;

namespace AplicacionMoodle.Data
{
    public class AppContexto: DbContext
    {

        public AppContexto(DbContextOptions<AppContexto> options) : base(options)
        {
        }


        public DbSet<Modelos.Usuario> Usuario { get; set; }
        public DbSet<Modelos.Productos> Productos { get; set; }
        public DbSet<Modelos.Planes> Planes { get; set; }

        

    }
}
