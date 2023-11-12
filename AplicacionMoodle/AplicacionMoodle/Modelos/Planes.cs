using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionMoodle.Modelos
{
    public class Planes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string plan { get; set; }

        public string Descripcion { get; set; }

        public string Icono { get; set; }
        public float Valor { get; set; }
        

    }
}
