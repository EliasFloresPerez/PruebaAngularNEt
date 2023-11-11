using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionMoodle.Modelos
{
    public class Productos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Estado { get; set; }

        public string Detalle { get; set; }

        //El tipo de producto es un ID , seria genial crear una tabla para enlazar el Id con el nombre
        public int Tipo { get; set; }

        public float Precio { get; set; }



    }
}
