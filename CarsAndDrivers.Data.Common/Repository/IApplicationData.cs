namespace CarsAndDrivers.Data.Common.Repository
{
    using System;

    public interface IApplicationData : IDisposable
    {
        //IRepository<Album> Albums { get; } //Change

        //DeletableEntityRepository<Students> Students { get; } //Change

        int SaveChanges();
    }
}
