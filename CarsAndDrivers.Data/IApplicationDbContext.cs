namespace CarsAndDrivers.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using CarsAndDrivers.Models;

    public interface IApplicationDbContext
    {
        IDbSet<UserProfile> UserProfiles { get; set; } //Change & Add

        IDbSet<CarProfile> CarProfiles { get; set; }

        IDbSet<Comments> Comments { get; set; }

        IDbSet<CarManufacturer> CarManufacturers { get; set; }

        IDbSet<CarModel> CarModels { get; set; }

        IDbSet<Country> Countries { get; set; }


        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
        
        void Dispose();
    }
}
