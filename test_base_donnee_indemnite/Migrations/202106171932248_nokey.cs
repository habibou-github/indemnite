namespace test_base_donnee_indemnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nokey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdreVirements", "IdOrdreVirement", "dbo.OrdrePayments");
            DropForeignKey("dbo.Grades", "Cadre_IdCadre", "dbo.Cadres");
            DropForeignKey("dbo.Personnels", "Cadre_IdCadre", "dbo.Cadres");
            DropForeignKey("dbo.Personnels", "Corps_Idcorps", "dbo.Corps");
            DropForeignKey("dbo.OrdreMissions", "personel_IdPers", "dbo.Personnels");
            DropForeignKey("dbo.Personnels", "Grades_Idgrades", "dbo.Grades");
            DropForeignKey("dbo.OrdreMissions", "trajet_id_trajet", "dbo.Trajets");
            DropIndex("dbo.Personnels", new[] { "Cadre_IdCadre" });
            DropIndex("dbo.Personnels", new[] { "Corps_Idcorps" });
            DropIndex("dbo.Personnels", new[] { "Grades_Idgrades" });
            DropIndex("dbo.Grades", new[] { "Cadre_IdCadre" });
            DropIndex("dbo.OrdreMissions", new[] { "personel_IdPers" });
            DropIndex("dbo.OrdreMissions", new[] { "trajet_id_trajet" });
            DropIndex("dbo.OrdreVirements", new[] { "IdOrdreVirement" });
            RenameColumn(table: "dbo.Grades", name: "Cadre_IdCadre", newName: "IdCadre");
            RenameColumn(table: "dbo.Personnels", name: "Cadre_IdCadre", newName: "IdCadre");
            RenameColumn(table: "dbo.Personnels", name: "Corps_Idcorps", newName: "Idcorps");
            RenameColumn(table: "dbo.OrdreMissions", name: "personel_IdPers", newName: "IdPers");
            RenameColumn(table: "dbo.Personnels", name: "Grades_Idgrades", newName: "Idgrades");
            RenameColumn(table: "dbo.OrdrePayments", name: "ordermission_idOrdremission", newName: "idOrdremission");
            RenameColumn(table: "dbo.OrdreMissions", name: "trajet_id_trajet", newName: "id_trajet");
            RenameIndex(table: "dbo.OrdrePayments", name: "IX_ordermission_idOrdremission", newName: "IX_idOrdremission");
            AddColumn("dbo.OrdrePayments", "IdOrdreVirement", c => c.Int(nullable: false));
            AddColumn("dbo.OrdreVirements", "IdOrdrePayment", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnels", "IdCadre", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnels", "Idcorps", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnels", "Idgrades", c => c.Int(nullable: false));
            AlterColumn("dbo.Grades", "IdCadre", c => c.Int(nullable: false));
            AlterColumn("dbo.OrdreMissions", "IdPers", c => c.Int(nullable: true));
            AlterColumn("dbo.OrdreMissions", "id_trajet", c => c.Int(nullable: true));
            CreateIndex("dbo.Personnels", "Idcorps");
            CreateIndex("dbo.Personnels", "IdCadre");
            CreateIndex("dbo.Personnels", "Idgrades");
            CreateIndex("dbo.OrdreMissions", "IdPers");
            CreateIndex("dbo.OrdreMissions", "id_trajet");
            CreateIndex("dbo.Grades", "IdCadre");
            AddForeignKey("dbo.Grades", "IdCadre", "dbo.Cadres", "IdCadre", cascadeDelete: true);
            AddForeignKey("dbo.Personnels", "IdCadre", "dbo.Cadres", "IdCadre", cascadeDelete: true);
            AddForeignKey("dbo.Personnels", "Idcorps", "dbo.Corps", "Idcorps", cascadeDelete: true);
            AddForeignKey("dbo.OrdreMissions", "IdPers", "dbo.Personnels", "IdPers", cascadeDelete: true);
            AddForeignKey("dbo.Personnels", "Idgrades", "dbo.Grades", "Idgrades", cascadeDelete: false);
            AddForeignKey("dbo.OrdreMissions", "id_trajet", "dbo.Trajets", "id_trajet", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdreMissions", "id_trajet", "dbo.Trajets");
            DropForeignKey("dbo.Personnels", "Idgrades", "dbo.Grades");
            DropForeignKey("dbo.OrdreMissions", "IdPers", "dbo.Personnels");
            DropForeignKey("dbo.Personnels", "Idcorps", "dbo.Corps");
            DropForeignKey("dbo.Personnels", "IdCadre", "dbo.Cadres");
            DropForeignKey("dbo.Grades", "IdCadre", "dbo.Cadres");
            DropIndex("dbo.Grades", new[] { "IdCadre" });
            DropIndex("dbo.OrdreMissions", new[] { "id_trajet" });
            DropIndex("dbo.OrdreMissions", new[] { "IdPers" });
            DropIndex("dbo.Personnels", new[] { "Idgrades" });
            DropIndex("dbo.Personnels", new[] { "IdCadre" });
            DropIndex("dbo.Personnels", new[] { "Idcorps" });
            AlterColumn("dbo.OrdreMissions", "id_trajet", c => c.Int());
            AlterColumn("dbo.OrdreMissions", "IdPers", c => c.Int());
            AlterColumn("dbo.Grades", "IdCadre", c => c.Int());
            AlterColumn("dbo.Personnels", "Idgrades", c => c.Int());
            AlterColumn("dbo.Personnels", "Idcorps", c => c.Int());
            AlterColumn("dbo.Personnels", "IdCadre", c => c.Int());
            DropColumn("dbo.OrdreVirements", "IdOrdrePayment");
            DropColumn("dbo.OrdrePayments", "IdOrdreVirement");
            RenameIndex(table: "dbo.OrdrePayments", name: "IX_idOrdremission", newName: "IX_ordermission_idOrdremission");
            RenameColumn(table: "dbo.OrdreMissions", name: "id_trajet", newName: "trajet_id_trajet");
            RenameColumn(table: "dbo.OrdrePayments", name: "idOrdremission", newName: "ordermission_idOrdremission");
            RenameColumn(table: "dbo.Personnels", name: "Idgrades", newName: "Grades_Idgrades");
            RenameColumn(table: "dbo.OrdreMissions", name: "IdPers", newName: "personel_IdPers");
            RenameColumn(table: "dbo.Personnels", name: "Idcorps", newName: "Corps_Idcorps");
            RenameColumn(table: "dbo.Personnels", name: "IdCadre", newName: "Cadre_IdCadre");
            RenameColumn(table: "dbo.Grades", name: "IdCadre", newName: "Cadre_IdCadre");
            CreateIndex("dbo.OrdreVirements", "IdOrdreVirement");
            CreateIndex("dbo.OrdreMissions", "trajet_id_trajet");
            CreateIndex("dbo.OrdreMissions", "personel_IdPers");
            CreateIndex("dbo.Grades", "Cadre_IdCadre");
            CreateIndex("dbo.Personnels", "Grades_Idgrades");
            CreateIndex("dbo.Personnels", "Corps_Idcorps");
            CreateIndex("dbo.Personnels", "Cadre_IdCadre");
            AddForeignKey("dbo.OrdreMissions", "trajet_id_trajet", "dbo.Trajets", "id_trajet");
            AddForeignKey("dbo.Personnels", "Grades_Idgrades", "dbo.Grades", "Idgrades");
            AddForeignKey("dbo.OrdreMissions", "personel_IdPers", "dbo.Personnels", "IdPers");
            AddForeignKey("dbo.Personnels", "Corps_Idcorps", "dbo.Corps", "Idcorps");
            AddForeignKey("dbo.Personnels", "Cadre_IdCadre", "dbo.Cadres", "IdCadre");
            AddForeignKey("dbo.Grades", "Cadre_IdCadre", "dbo.Cadres", "IdCadre");
            AddForeignKey("dbo.OrdreVirements", "IdOrdreVirement", "dbo.OrdrePayments", "IdOrdrePayment");
        }
    }
}
