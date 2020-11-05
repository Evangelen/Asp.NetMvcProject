namespace LeaveManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Long(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Long(nullable: false, identity: true),
                        EmpName = c.String(),
                        EmpRole = c.String(),
                        EmpEmailId = c.String(),
                        DepartmentId = c.Long(nullable: false),
                        Education_EduId = c.Long(),
                        Education_EduId1 = c.Long(),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_EduId)
                .ForeignKey("dbo.Educations", t => t.Education_EduId1)
                .Index(t => t.DepartmentId)
                .Index(t => t.Education_EduId)
                .Index(t => t.Education_EduId1);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EduId = c.Long(nullable: false, identity: true),
                        EduLevel = c.String(),
                        EduYOP = c.Int(nullable: false),
                        Employees_EmpId = c.Long(),
                    })
                .PrimaryKey(t => t.EduId)
                .ForeignKey("dbo.Employees", t => t.Employees_EmpId)
                .Index(t => t.Employees_EmpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "Employees_EmpId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Education_EduId1", "dbo.Educations");
            DropForeignKey("dbo.Employees", "Education_EduId", "dbo.Educations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Educations", new[] { "Employees_EmpId" });
            DropIndex("dbo.Employees", new[] { "Education_EduId1" });
            DropIndex("dbo.Employees", new[] { "Education_EduId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.Educations");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
