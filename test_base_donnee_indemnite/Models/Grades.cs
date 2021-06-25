using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_base_donnee_indemnite.Models
{ 
    public class Grades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idgrades { get; set; }
        [Required]
        public string Nom { get; set; }
        public string NomComplet { get; set; }
        public string Nomarabe { get; set; }

        public int IdCadre { get; set; }

        public virtual IList<Personnel> Personnels { get; set; }
    }
}
