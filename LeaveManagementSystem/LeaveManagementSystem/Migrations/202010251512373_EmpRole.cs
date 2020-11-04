namespace LeaveManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmpRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmpRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmpRole");
        }
    }
}
