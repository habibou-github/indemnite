
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test_base_donnee_indemnite.Models
{
    public class Personnel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPers { get; set; }
        [Required(ErrorMessage = "Saisir le Nom.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Saisir le Prenom.")]
        public string Prenom { get; set; }

        public string nomarabe { get; set; }
        public string prenomarabe { get; set; }

        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Saisir le CIN.")]
        public string CIN { get; set; }
        public string DRPP { get; set; }
        [Required(ErrorMessage = "saisir l'email."), EmailAddress(ErrorMessage = "adresse email est  invalide.")]
        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Sexe { get; set; }
        public string Gsm1 { get; set; }
        public string Gsm2 { get; set; }
        public string liencv { get; set; }
        public string ServiceAffecte { get; set; }
        [Required(ErrorMessage = "séléctionnez votre situation administrative.")]
        public string SituationAdministratif { get; set; }
        public string SituationFamiliale { get; set; }
        public int NombreEnfant { get; set; }
        /* [Required(ErrorMessage = "Saisir la date")]
         [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]*/
        [Required(ErrorMessage = "Saisir la date de naissance")]
        public DateTime DateNaissance { get; set; }
        public DateTime DateRecrutement { get; set; }
        public DateTime DateRecrutementENSA { get; set; }
        public DateTime DateEffetgrade{ get; set; }
        public DateTime DateEffetEchelon { get; set; }
        public DateTime DateDebut{ get; set; }
        public DateTime DateFin { get; set; }
        public string renouvelement { get; set; }

        public string specialite { get; set; }
        public string diplome { get; set; }
        public string ecolediplome { get; set; }
        public string anneediplome{ get; set; }
        public string photo { get; set; }

        public bool show1 { get; set; }
        public bool show2{ get; set; }
        public string echelon { get; set; }

        /***************Partie de recherche scientifique*********************/
        public string TypeqEntiterecherches { get; set; }//il s'agit de laboratoire ou équipe
        public string Nomentiterecherches { get; set; }
        public string Lieuentiterecherches { get; set; }
        public string Thematiquerecherches { get; set; }
        public string Journauxrecherches { get; set; }

        [Required(ErrorMessage = "séléctionnez votre appartenance")]
        public string NomCorps { get; set; }
        public string NomCadre { get; set; }
        public string NomGrades { get; set; }


        public virtual Corps Corps { get; set; } 

        public virtual Cadre Cadre{ get; set; }

        public virtual Grades Grades { get; set; }
        [Required]
        public virtual List<OrdreMission> ordermissions { get; set; }

        /*Données réservées aux contractuel*/
        public string Typecontract { get; set; }
        public string NumContract { get; set; }
        public string Société { get; set; }
        public string donnesContract;//nombre deffet
        public DateTime DateContract { get; set; }





    }
}
