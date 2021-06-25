using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projet_asp.Models
{
    public class Parametre_paiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_param_paiement { get; set; }
        public int Art { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
    }
}