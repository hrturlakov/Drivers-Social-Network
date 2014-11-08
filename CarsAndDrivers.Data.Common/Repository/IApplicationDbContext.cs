namespace CarsAndDrivers.Data.Common.Repository
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext
    {
        //IDbSet<Article> Articles { get; set; } //Change & Add


        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
        
        void Dispose();
    }
}
