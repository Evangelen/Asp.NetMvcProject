namespace Company.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecialPermission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsSpecialPermission", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsSpecialPermission");
        }
    }
}
