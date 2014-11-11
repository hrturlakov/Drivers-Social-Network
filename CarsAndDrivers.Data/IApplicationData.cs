namespace CarsAndDrivers.Data
{
    using System;

    using CarsAndDrivers.Data.Common.Repository;
    using CarsAndDrivers.Models;

    public interface IApplicationData : IDisposable
    {
        IRepository<UserProfile> UserProfiles { get; } //Change

        IRepository<CarProfile> CarProfiles { get; } //Change

        IRepository<CarManufacturer> CarManufacturers { get; } //Change

        IRepository<CarModel> CarModels { get; } //Change

        IRepository<Country> Countries { get; } //Change

        IRepository<ApplicationUser> Users { get; }

        //IDeletableEntityRepository<UserDetails> UsersDetails { get; } //Change

        int SaveChanges();
    }
}
