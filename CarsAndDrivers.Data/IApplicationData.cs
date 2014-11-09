namespace CarsAndDrivers.Data
{
    using CarsAndDrivers.Data.Common.Repository;
    using CarsAndDrivers.Models;
    using System;

    public interface IApplicationData : IDisposable
    {
        IRepository<UserProfile> UserProfiles { get; } //Change

        IRepository<ApplicationUser> Users { get; }

        //IDeletableEntityRepository<UserDetails> UsersDetails { get; } //Change

        int SaveChanges();
    }
}
