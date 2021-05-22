using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_base_donnee_indemnite.Models
{ /* pa-a,pa-b;pa-c;pa-d;ph-a;ph-b;ph-c;pes-a;pes... ;ingenieur 1er grade,ingenieur grade principal,ingenieur
   * en chef 1er grade;ingenieur en chef grade principal;technicien 2eme grade,technieciern 1 er grade;
   * administrateur 1er grade,administrateur 2eme grade...
   * administrateur adjoint 1er grade,administrateur adjoint 2eme grade...*/
    public class Grades
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idgrades { get; set; }
        [Required]
        public string Nom { get; set; }
        public string NomComplet { get; set; }
        public string Nomarabe { get; set; }

        //[ForeignKey("Cadre")]
        //public int Id_grade { get; set; }
        public virtual Cadre Cadre{ get; set; }

        public virtual IList<Personnel> Personnels { get; set; }
    }
}
