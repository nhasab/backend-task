namespace netways_task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        LoginName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LoginName);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        LoginName = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        IsActive = c.Boolean(),
                        Salary = c.Double(nullable: false),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.LoginName)
                .ForeignKey("dbo.Countries", t => t.Country_ID)
                .Index(t => t.Country_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Country_ID", "dbo.Countries");
            DropIndex("dbo.UserProfiles", new[] { "Country_ID" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Countries");
            DropTable("dbo.Accounts");
        }
    }
}
