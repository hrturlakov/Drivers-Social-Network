namespace CarsAndDrivers.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CarsAndDrivers.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CarsAndDrivers.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.UserProfiles.Count() != 0)
            {
                return;
            }

            context.UserProfiles.Add(new UserProfile() { Name = "IcoPico" });
            context.UserProfiles.Add(new UserProfile() { Name = "LeriKen" });
            context.UserProfiles.Add(new UserProfile() { Name = "SexyPoli" });
        }
    }
}
