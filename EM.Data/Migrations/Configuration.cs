namespace EM.Data.Migrations
{
    using EM.Data.EF;
    using EM.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EM.Data.EF.EMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EM.Data.EF.EMDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            EMDbContext dbContext = new EMDbContext();
            Salary salary1 = new Salary()
            {
                GrossSales = 50,
                CommissionRate = 150,
                BasicSalary = 990
            };
            dbContext.Salaries.Add(salary1);
            dbContext.SaveChanges();

            Salary salary2 = new Salary()
            {
                GrossSales = 40,
                CommissionRate = 120,
                BasicSalary = 1090
            };
            dbContext.Salaries.Add(salary2);
            dbContext.SaveChanges();

            Salary salary3 = new Salary()
            {
                GrossSales = 60,
                CommissionRate = 80,
                BasicSalary = 1150
            };
            dbContext.Salaries.Add(salary3);
            dbContext.SaveChanges();

            Employee employee1 = new Employee()
            {
                FirstName = "Tùng",
                LastName = "Võ Văn",
                Address = "Lấp Vò, Đồng Tháp.",
                PhoneNumber = "0123456789",
                SalaryId = 1
            };
            dbContext.Employees.Add(employee1);
            dbContext.SaveChanges();

            Employee employee2 = new Employee()
            {
                FirstName = "ABC",
                LastName = "Nguyễn Văn",
                Address = "Sa Đéc, Đồng Tháp.",
                PhoneNumber = "11111111111",
                SalaryId = 2
            };
            dbContext.Employees.Add(employee2);
            dbContext.SaveChanges();

            Employee employee4 = new Employee()
            {
                FirstName = "JKL",
                LastName = "Trần Thị",
                Address = "Q9, TP.HCM.",
                PhoneNumber = "777777777",
                SalaryId = 3
            };
            dbContext.Employees.Add(employee4);
            dbContext.SaveChanges();
        }
    }
}
