namespace CarsAndDrivers.Data
{
    using CarsAndDrivers.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext
    {
        IDbSet<UserProfile> UserProfiles { get; set; } //Change & Add


        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
        
        void Dispose();
    }
}
