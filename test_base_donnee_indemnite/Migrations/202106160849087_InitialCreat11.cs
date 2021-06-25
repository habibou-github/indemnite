namespace test_base_donnee_indemnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreat11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cadres",
                c => new
                    {
                        IdCadre = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        NomComplet = c.String(),
                        corps_Idcorps = c.Int(),
                    })
                .PrimaryKey(t => t.IdCadre)
                .ForeignKey("dbo.Corps", t => t.corps_Idcorps)
                .Index(t => t.corps_Idcorps);
            
            CreateTable(
                "dbo.Corps",
                c => new
                    {
                        Idcorps = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Idcorps);
            
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        IdPers = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        nomarabe = c.String(),
                        prenomarabe = c.String(),
                        Username = c.String(),
                        Role = c.String(),
                        Password = c.String(),
                        CIN = c.String(nullable: false),
                        DRPP = c.String(),
                        Email1 = c.String(nullable: false),
                        Email2 = c.String(),
                        Adresse = c.String(),
                        Ville = c.String(),
                        Sexe = c.String(),
                        Gsm1 = c.String(),
                        Gsm2 = c.String(),
                        liencv = c.String(),
                        ServiceAffecte = c.String(),
                        SituationAdministratif = c.String(nullable: false),
                        SituationFamiliale = c.String(),
                        NombreEnfant = c.Int(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                        DateRecrutement = c.DateTime(nullable: false),
                        DateRecrutementENSA = c.DateTime(nullable: false),
                        DateEffetgrade = c.DateTime(nullable: false),
                        DateEffetEchelon = c.DateTime(nullable: false),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        renouvelement = c.String(),
                        specialite = c.String(),
                        diplome = c.String(),
                        ecolediplome = c.String(),
                        anneediplome = c.String(),
                        photo = c.String(),
                        show1 = c.Boolean(nullable: false),
                        show2 = c.Boolean(nullable: false),
                        echelon = c.Int(nullable: false),
                        Echelle = c.Int(nullable: false),
                        TypeqEntiterecherches = c.String(),
                        Nomentiterecherches = c.String(),
                        Lieuentiterecherches = c.String(),
                        Thematiquerecherches = c.String(),
                        Journauxrecherches = c.String(),
                        NomCorps = c.String(nullable: false),
                        NomCadre = c.String(),
                        NomGrades = c.String(),
                        Typecontract = c.String(),
                        NumContract = c.String(),
                        Société = c.String(),
                        DateContract = c.DateTime(nullable: false),
                        Cadre_IdCadre = c.Int(),
                        Corps_Idcorps = c.Int(),
                        Grades_Idgrades = c.Int(),
                    })
                .PrimaryKey(t => t.IdPers)
                .ForeignKey("dbo.Cadres", t => t.Cadre_IdCadre)
                .ForeignKey("dbo.Corps", t => t.Corps_Idcorps)
                .ForeignKey("dbo.Grades", t => t.Grades_Idgrades)
                .Index(t => t.Cadre_IdCadre)
                .Index(t => t.Corps_Idcorps)
                .Index(t => t.Grades_Idgrades);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Idgrades = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        NomComplet = c.String(),
                        Nomarabe = c.String(),
                        Cadre_IdCadre = c.Int(),
                    })
                .PrimaryKey(t => t.Idgrades)
                .ForeignKey("dbo.Cadres", t => t.Cadre_IdCadre)
                .Index(t => t.Cadre_IdCadre);
            
            CreateTable(
                "dbo.OrdreMissions",
                c => new
                    {
                        idOrdremission = c.Int(nullable: false, identity: true),
                        numero = c.String(),
                        etat = c.Boolean(nullable: false),
                        name_respo_mission = c.String(),
                        dateDepart = c.DateTime(nullable: false),
                        dateArrivee = c.DateTime(nullable: false),
                        heureDepart = c.String(),
                        heureArrivee = c.String(),
                        echlon = c.Int(nullable: false),
                        matricule = c.String(),
                        grade = c.String(),
                        objetDepart = c.String(),
                        moyenTransport = c.String(),
                        nombreCheuvaux = c.Int(nullable: false),
                        montant_total = c.Single(nullable: false),
                        personel_IdPers = c.Int(),
                        trajet_id_trajet = c.Int(),
                    })
                .PrimaryKey(t => t.idOrdremission)
                .ForeignKey("dbo.Personnels", t => t.personel_IdPers)
                .ForeignKey("dbo.Trajets", t => t.trajet_id_trajet)
                .Index(t => t.personel_IdPers)
                .Index(t => t.trajet_id_trajet);
            
            CreateTable(
                "dbo.OrdrePayments",
                c => new
                    {
                        IdOrdrePayment = c.Int(nullable: false, identity: true),
                        totalDeplacement = c.Double(nullable: false),
                        tatalKilo = c.Double(nullable: false),
                        ordermission_idOrdremission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdOrdrePayment)
                .ForeignKey("dbo.OrdreMissions", t => t.ordermission_idOrdremission, cascadeDelete: true)
                .Index(t => t.ordermission_idOrdremission);
            
            CreateTable(
                "dbo.OrdreVirements",
                c => new
                    {
                        IdOrdreVirement = c.Int(nullable: false, identity: true),
                        numero = c.String(),
                        idAdmin = c.Int(nullable: false),
                        numeroCompte = c.String(),
                    })
                .PrimaryKey(t => t.IdOrdreVirement)
                .ForeignKey("dbo.OrdrePayments", t => t.IdOrdreVirement)
                .Index(t => t.IdOrdreVirement);
            
            CreateTable(
                "dbo.Trajets",
                c => new
                    {
                        id_trajet = c.Int(nullable: false, identity: true),
                        villeDepart = c.String(),
                        villeArrivee = c.String(),
                        distance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_trajet);
            
            CreateTable(
                "dbo.Parametre_paiement",
                c => new
                    {
                        id_param_paiement = c.Int(nullable: false, identity: true),
                        Art = c.Int(nullable: false),
                        num1 = c.Int(nullable: false),
                        num2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_param_paiement);
            
            CreateTable(
                "dbo.Parametre_voiture",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre_cheveau_min = c.Int(nullable: false),
                        nombre_cheveau_max = c.Int(nullable: false),
                        prix_par_km = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        valeur1 = c.Int(nullable: false),
                        valeur2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Parametre_image",
                c => new
                    {
                        id_param_img = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        footer = c.String(),
                        header = c.String(),
                        background = c.String(),
                    })
                .PrimaryKey(t => t.id_param_img);
            
            CreateTable(
                "dbo.ServiceEconomique",
                c => new
                    {
                        IdPers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPers)
                .ForeignKey("dbo.Personnels", t => t.IdPers)
                .Index(t => t.IdPers);
            
            CreateTable(
                "dbo.ServicePersonnel",
                c => new
                    {
                        IdPers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPers)
                .ForeignKey("dbo.Personnels", t => t.IdPers)
                .Index(t => t.IdPers);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicePersonnel", "IdPers", "dbo.Personnels");
            DropForeignKey("dbo.ServiceEconomique", "IdPers", "dbo.Personnels");
            DropForeignKey("dbo.OrdreMissions", "trajet_id_trajet", "dbo.Trajets");
            DropForeignKey("dbo.OrdreMissions", "personel_IdPers", "dbo.Personnels");
            DropForeignKey("dbo.OrdreVirements", "IdOrdreVirement", "dbo.OrdrePayments");
            DropForeignKey("dbo.OrdrePayments", "ordermission_idOrdremission", "dbo.OrdreMissions");
            DropForeignKey("dbo.Personnels", "Grades_Idgrades", "dbo.Grades");
            DropForeignKey("dbo.Grades", "Cadre_IdCadre", "dbo.Cadres");
            DropForeignKey("dbo.Personnels", "Corps_Idcorps", "dbo.Corps");
            DropForeignKey("dbo.Personnels", "Cadre_IdCadre", "dbo.Cadres");
            DropForeignKey("dbo.Cadres", "corps_Idcorps", "dbo.Corps");
            DropIndex("dbo.ServicePersonnel", new[] { "IdPers" });
            DropIndex("dbo.ServiceEconomique", new[] { "IdPers" });
            DropIndex("dbo.OrdreVirements", new[] { "IdOrdreVirement" });
            DropIndex("dbo.OrdrePayments", new[] { "ordermission_idOrdremission" });
            DropIndex("dbo.OrdreMissions", new[] { "trajet_id_trajet" });
            DropIndex("dbo.OrdreMissions", new[] { "personel_IdPers" });
            DropIndex("dbo.Grades", new[] { "Cadre_IdCadre" });
            DropIndex("dbo.Personnels", new[] { "Grades_Idgrades" });
            DropIndex("dbo.Personnels", new[] { "Corps_Idcorps" });
            DropIndex("dbo.Personnels", new[] { "Cadre_IdCadre" });
            DropIndex("dbo.Cadres", new[] { "corps_Idcorps" });
            DropTable("dbo.ServicePersonnel");
            DropTable("dbo.ServiceEconomique");
            DropTable("dbo.Parametre_image");
            DropTable("dbo.Parameters");
            DropTable("dbo.Parametre_voiture");
            DropTable("dbo.Parametre_paiement");
            DropTable("dbo.Trajets");
            DropTable("dbo.OrdreVirements");
            DropTable("dbo.OrdrePayments");
            DropTable("dbo.OrdreMissions");
            DropTable("dbo.Grades");
            DropTable("dbo.Personnels");
            DropTable("dbo.Corps");
            DropTable("dbo.Cadres");
        }
    }
}
