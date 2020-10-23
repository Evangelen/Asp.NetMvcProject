namespace LeaveManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VarCharMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "ImageUrl", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ImageUrl", c => c.String());
        }
    }
}
