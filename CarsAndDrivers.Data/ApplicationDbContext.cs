namespace CarsAndDrivers.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using CarsAndDrivers.Data.Common.Models;
    using CarsAndDrivers.Data.Migrations;
    using CarsAndDrivers.Models;
    using CarsAndDrivers.Data.Common.Repository;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual IDbSet<UserProfile> UserProfiles { get; set; }

        public virtual IDbSet<CarProfile> CarProfiles { get; set; }

        public virtual IDbSet<CarPicture> CarPictures { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<CarManufacturer> CarManufacturers { get; set; }

        public virtual IDbSet<CarModel> CarModels { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
