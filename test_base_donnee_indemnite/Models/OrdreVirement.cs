// File:    OrdreDeVirement.cs
// Author:  werty
// Created: Saturday, May 15, 2021 7:54:54 PM
// Purpose: Definition of Class OrdreDeVirement

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_base_donnee_indemnite.Models
{
    public class OrdreVirement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrdreVirement { get; set; }

        public String numero { get; set; }

        public int idAdmin { get; set; }

        public String numeroCompte { get; set; }

        [Required]
        public virtual OrdrePayment orderPayment { get; set; }

        [Required]
        public virtual OrdrePaiement orderpaiment { get; set; }
    }
}