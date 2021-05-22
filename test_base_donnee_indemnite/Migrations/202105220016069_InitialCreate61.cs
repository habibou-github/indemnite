namespace test_base_donnee_indemnite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdreMissions", "grade", c => c.String());
            AddColumn("dbo.OrdreMissions", "objetDepart", c => c.String());
            AddColumn("dbo.OrdreMissions", "moyenTransport", c => c.String());
            AddColumn("dbo.OrdreMissions", "nombreCheuvaux", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdreMissions", "nombreCheuvaux");
            DropColumn("dbo.OrdreMissions", "moyenTransport");
            DropColumn("dbo.OrdreMissions", "objetDepart");
            DropColumn("dbo.OrdreMissions", "grade");
        }
    }
}
