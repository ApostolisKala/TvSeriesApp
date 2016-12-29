namespace TvSeriesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        SerieID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleasedDate = c.DateTime(nullable: false),
                        NumberOfSeasons = c.Int(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.SerieID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Series");
        }
    }
}
