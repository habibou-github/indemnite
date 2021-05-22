using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace test_base_donnee_indemnite.Models
{
    public class DbContextIndimnite : DbContext
    {
        public DbContextIndimnite() : base("name=DbContextIndimnite")
        {

        }

    

        public DbSet<Personnel> personnels { get; set; }
        public DbSet<Cadre> cadres { get; set; }
        public DbSet<Corps> corp { get; set; }
        public DbSet<Grades> grade { get; set; }
        public DbSet<OrdreMission> ordremission { get; set; }
        public DbSet<OrdrePaiement> ordrepaiement { get; set; }
        public DbSet<OrdreVirement> ordrevirement { get; set; }
        public DbSet<Trajet> trajet { get; set; }
        public DbSet<ServiceEconomique> serviceeconomique { get; set; }
        public DbSet<ServicePersonnel> servicepersonnel { get; set; }
        public DbSet<Parameter> parametre { get; set; }
    }
}