namespace TvSeriesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "Rating");
        }
    }
}
