
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_base_donnee_indemnite.Models
{
    public class OrdrePaiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrderPaiement { get; set; }
        public double totalDeplacement { get; set; }
        public double tatalKilo { get; set; }

        public OrdreVirement ordreVirement { get; set; }

        public int id_mission { get; set; }
        [Required]
        public virtual OrdreMission ordermission { get; set; }

    }

}
