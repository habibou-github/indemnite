// File:    OrdreDePayment.cs
// Author:  werty
// Created: Saturday, May 15, 2021 7:54:54 PM
// Purpose: Definition of Class OrdreDePayment

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_base_donnee_indemnite.Models
{
    public class OrdrePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrdrePayment { get; set; }

        //Amount For Hotel and food
        public double totalDeplacement { get; set; }

        //Amount for Fuel
        public double tatalKilo { get; set; }
        public OrdreVirement ordreVirement { get; set; }

        [Required]
        public virtual OrdreMission ordermission { get; set; }

    }
}