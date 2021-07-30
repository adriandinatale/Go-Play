using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoPlay.web.Models
{
    public class Proyecto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public string NombreObra { get; set; }

        public List<ListaReproduccion> Tracks { get; set; }

    }

    
   
}

   