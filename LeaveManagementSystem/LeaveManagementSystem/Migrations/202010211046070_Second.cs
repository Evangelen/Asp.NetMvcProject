namespace LeaveManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Education_EduId", "dbo.Educations");
            DropForeignKey("dbo.Employees", "Education_EduId1", "dbo.Educations");
            DropForeignKey("dbo.Educations", "Employees_EmpId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Education_EduId" });
            DropIndex("dbo.Employees", new[] { "Education_EduId1" });
            DropIndex("dbo.Educations", new[] { "Employees_EmpId" });
            CreateTable(
                "dbo.EducationEmployees",
                c => new
                    {
                        Education_EduId = c.Long(nullable: false),
                        Employees_EmpId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_EduId, t.Employees_EmpId })
                .ForeignKey("dbo.Educations", t => t.Education_EduId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employees_EmpId, cascadeDelete: true)
                .Index(t => t.Education_EduId)
                .Index(t => t.Employees_EmpId);
            
            DropColumn("dbo.Employees", "Education_EduId");
            DropColumn("dbo.Employees", "Education_EduId1");
            DropColumn("dbo.Educations", "Employees_EmpId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Educations", "Employees_EmpId", c => c.Long());
            AddColumn("dbo.Employees", "Education_EduId1", c => c.Long());
            AddColumn("dbo.Employees", "Education_EduId", c => c.Long());
            DropForeignKey("dbo.EducationEmployees", "Employees_EmpId", "dbo.Employees");
            DropForeignKey("dbo.EducationEmployees", "Education_EduId", "dbo.Educations");
            DropIndex("dbo.EducationEmployees", new[] { "Employees_EmpId" });
            DropIndex("dbo.EducationEmployees", new[] { "Education_EduId" });
            DropTable("dbo.EducationEmployees");
            CreateIndex("dbo.Educations", "Employees_EmpId");
            CreateIndex("dbo.Employees", "Education_EduId1");
            CreateIndex("dbo.Employees", "Education_EduId");
            AddForeignKey("dbo.Educations", "Employees_EmpId", "dbo.Employees", "EmpId");
            AddForeignKey("dbo.Employees", "Education_EduId1", "dbo.Educations", "EduId");
            AddForeignKey("dbo.Employees", "Education_EduId", "dbo.Educations", "EduId");
        }
    }
}
