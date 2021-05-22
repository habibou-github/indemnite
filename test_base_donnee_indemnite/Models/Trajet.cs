// File:    Trajet.cs
// Author:  werty
// Created: Saturday, May 15, 2021 7:54:54 PM
// Purpose: Definition of Class Trajet

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_base_donnee_indemnite.Models
{
    public class Trajet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_trajet { get; set; }
        public String villeDepart { get; set; }
        public String villeArrivee { get; set; }
        public int distance { get; set; }
        public virtual IList<OrdreMission> OrdreMissions { get; set; }
    }
}