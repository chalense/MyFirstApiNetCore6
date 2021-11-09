using Microsoft.EntityFrameworkCore;
namespace prueba2022.Models
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options) : base(options) { }
        public DbSet<Prueba> Prueba { get; set; }
    }

    public class Conectar
    {
        private const string cadenaConexion = "server=localhost;port=3306;database=prueba;userid=root;psw=";
        public static Conexion crearConexion()
        {
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion(constructor.Options);
            return cn;
        }
    }
}
