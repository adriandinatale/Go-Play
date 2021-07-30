using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace GoPlay.web.Models
{
    public class ListaReproduccion
    {
  

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public int Numero { get; set; }

        public string Nombre { get; set; }

        public byte[] Pista { get; set; }

        public string Detalle { get; set; }

        public int ProyectoID { get; set; }

        [NotMapped]
        public IFormFile MyFile { get; set; }
        

















    }
}