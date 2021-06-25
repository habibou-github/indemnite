using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projet_asp.Models
{
    public class Parametre_voiture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int nombre_cheveau_min { get; set; }

        public int nombre_cheveau_max { get; set; }

        public float prix_par_km { get; set; }
    }
}