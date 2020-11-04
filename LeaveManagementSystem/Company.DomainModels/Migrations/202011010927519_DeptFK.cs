namespace Company.DomainModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeptFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Department_DeptId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Department_DeptId", newName: "DeptId");
            AlterColumn("dbo.AspNetUsers", "DeptId", c => c.Long(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DeptId");
            AddForeignKey("dbo.AspNetUsers", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DeptId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "DeptId" });
            AlterColumn("dbo.AspNetUsers", "DeptId", c => c.Long());
            RenameColumn(table: "dbo.AspNetUsers", name: "DeptId", newName: "Department_DeptId");
            CreateIndex("dbo.AspNetUsers", "Department_DeptId");
            AddForeignKey("dbo.AspNetUsers", "Department_DeptId", "dbo.Departments", "DeptId");
        }
    }
}
