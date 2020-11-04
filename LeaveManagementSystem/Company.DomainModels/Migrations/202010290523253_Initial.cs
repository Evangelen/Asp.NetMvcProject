namespace Company.DomainModels.Migrations
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmpName = c.String(),
                        EmpPosition = c.String(),
                        EmpRole = c.String(),
                        EmpEmailId = c.String(),
                        ImageUrl = c.String(unicode: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Department_DeptId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_DeptId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Department_DeptId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EduId = c.Long(nullable: false, identity: true),
                        EduLevel = c.String(),
                        EduYOP = c.Int(nullable: false),
                        EmpList_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EduId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmpList_Id)
                .Index(t => t.EmpList_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        Employees_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LeaveId)
                .ForeignKey("dbo.AspNetUsers", t => t.Employees_Id)
                .ForeignKey("dbo.LeaveStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfLeaves", t => t.LeaveTypeId, cascadeDelete: true)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.StatusId)
                .Index(t => t.Employees_Id);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Leaves", "LeaveTypeId", "dbo.TypeOfLeaves");
            DropForeignKey("dbo.Leaves", "StatusId", "dbo.LeaveStatus");
            DropForeignKey("dbo.Leaves", "Employees_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Educations", "EmpList_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Leaves", new[] { "Employees_Id" });
            DropIndex("dbo.Leaves", new[] { "StatusId" });
            DropIndex("dbo.Leaves", new[] { "LeaveTypeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Educations", new[] { "EmpList_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Department_DeptId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TypeOfLeaves");
            DropTable("dbo.LeaveStatus");
            DropTable("dbo.Leaves");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Educations");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Departments");
        }
    }
}
