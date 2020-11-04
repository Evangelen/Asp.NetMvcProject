namespace LeaveManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "EmpId", c => c.Long(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "EmpId", c => c.Long(nullable: false));
        }
    }
}
