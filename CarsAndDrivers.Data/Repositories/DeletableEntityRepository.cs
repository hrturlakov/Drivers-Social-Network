namespace CarsAndDrivers.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using CarsAndDrivers.Data.Common.Models;
    using CarsAndDrivers.Data.Common.Repository;
    using System;
    using System.Data.Entity.Infrastructure;

    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public DeletableEntityRepository(IApplicationDbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public void ActualDelete(T entity)
        {
            base.Delete(entity);
        }

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
