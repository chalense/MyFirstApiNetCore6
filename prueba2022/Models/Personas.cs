using System.ComponentModel.DataAnnotations;

namespace prueba2022.Models
{
    public class Prueba
    {
        [Key]
        public int idpersona { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }

    }
}
