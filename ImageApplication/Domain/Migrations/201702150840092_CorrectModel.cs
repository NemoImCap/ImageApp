namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageItems", "Description", c => c.String());
            DropTable("dbo.ImageDescriptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descirption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.ImageItems", "Description");
        }
    }
}
