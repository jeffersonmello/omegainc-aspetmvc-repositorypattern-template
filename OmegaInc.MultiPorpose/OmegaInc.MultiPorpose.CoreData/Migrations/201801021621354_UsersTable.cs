namespace OmegaInc.MultiPorpose.CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.users",
                c => new
                    {
                        guid = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 250),
                        email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.users");
        }
    }
}
