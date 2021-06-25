using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_base_donnee_indemnite.Models
{
    public class Corps
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idcorps { get; set; }
        [Required]
        public string  Nom{ get; set; }

        public virtual IList<Personnel> Personnels { get; set; }
        public virtual IList<Cadre> caders{ get; set; }
      

    }
}
