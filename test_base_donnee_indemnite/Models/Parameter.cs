// File:    Parameter.cs
// Author:  werty
// Created: Saturday, May 15, 2021 7:54:54 PM
// Purpose: Definition of Class Parameter

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace test_base_donnee_indemnite.Models
{
    public class Parameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public String nom { get; set; }

        public int valeur1 { get; set; }

        public int valeur2 { get; set; }
    }
}