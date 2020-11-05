namespace LeaveManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ImageUrl");
        }
    }
}
