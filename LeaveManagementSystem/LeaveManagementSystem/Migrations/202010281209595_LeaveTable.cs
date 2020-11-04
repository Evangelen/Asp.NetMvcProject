namespace LeaveManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveId = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        NoOfDays = c.Int(nullable: false),
                        Cause = c.String(),
                        LeaveTypeId = c.Long(nullable: false),
                        StatusId = c.Long(nullable: false),
                        EmpId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LeaveId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmpId)
                .ForeignKey("dbo.LeaveStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfLeaves", t => t.LeaveTypeId, cascadeDelete: true)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.StatusId)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.LeaveStatus",
                c => new
                    {
                        StatusId = c.Long(nullable: false, identity: true),
                        StatusName = c.String(),
                        StatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.TypeOfLeaves",
                c => new
                    {
                        LeaveTypeId = c.Long(nullable: false, identity: true),
                        LeaveTypeName = c.String(),
                        LeavesPerYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaves", "LeaveTypeId", "dbo.TypeOfLeaves");
            DropForeignKey("dbo.Leaves", "StatusId", "dbo.LeaveStatus");
            DropForeignKey("dbo.Leaves", "EmpId", "dbo.AspNetUsers");
            DropIndex("dbo.Leaves", new[] { "EmpId" });
            DropIndex("dbo.Leaves", new[] { "StatusId" });
            DropIndex("dbo.Leaves", new[] { "LeaveTypeId" });
            DropTable("dbo.TypeOfLeaves");
            DropTable("dbo.LeaveStatus");
            DropTable("dbo.Leaves");
        }
    }
}
