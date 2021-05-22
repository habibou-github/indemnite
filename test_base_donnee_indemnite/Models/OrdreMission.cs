// File:    OrdreDeMission.cs
// Author:  Hamza
// Created: Saturday, May 15, 2021 7:54:54 PM
// Purpose: Definition of Class OrdreDeMission

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace test_base_donnee_indemnite.Models
{

    public class OrdreMission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOrdremission { get; set; }

        public String numero { get; set; }

        public bool approvedByAdmin { get; set; }

        public bool approvedBySP { get; set; }

        public DateTime dateDepart { get; set; }

        public DateTime dateArrivee { get; set; }

        public String heureDepart { get; set; }

        public String heureArrivee { get; set; }

        public int echlon { get; set; }

        public String matricule { get; set; }

        public String grade { get; set; }

        public String objetDepart { get; set; }

        public String moyenTransport { get; set; }

        public int nombreCheuvaux { get; set; }

        public List<OrdrePaiement> ordrePaiement { get; set; }
        public List<OrdrePayment> ordrePayment { get; set; }
        [Required]
        public virtual Personnel personel { get; set; }
        [Required]
        public virtual Trajet trajet { get; set; }

    }
}