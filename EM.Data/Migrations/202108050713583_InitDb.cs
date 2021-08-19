namespace EM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(),
                        PhoneNumber = c.String(maxLength: 20),
                        Address = c.String(maxLength: 500),
                        Email = c.String(maxLength: 100),
                        SalaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salaries", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommissionRate = c.Double(nullable: false),
                        GrossSales = c.Double(nullable: false),
                        BasicSalary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SalaryId", "dbo.Salaries");
            DropIndex("dbo.Employees", new[] { "SalaryId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
        }
    }
}
