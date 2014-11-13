namespace CarsAndDrivers.Data
{
    using System;

    using CarsAndDrivers.Data.Common.Repository;
    using CarsAndDrivers.Models;

    public interface IApplicationData : IDisposable
    {
        IApplicationDbContext Context { get; }

        IRepository<UserProfile> UserProfiles { get; }

        IRepository<CarProfile> CarProfiles { get; }

        IRepository<CarManufacturer> CarManufacturers { get; }

        IRepository<CarModel> CarModels { get; }

        IRepository<Country> Countries { get; } 

        IRepository<ApplicationUser> Users { get; }

        //IDeletableEntityRepository<UserDetails> UsersDetails { get; } //Change

        int SaveChanges();
    }
}
