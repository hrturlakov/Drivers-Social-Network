using CarsAndDrivers.Data.Common.Models;
using CarsAndDrivers.Data.Common.Repository;
using CarsAndDrivers.Data.Repositories;
using CarsAndDrivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsAndDrivers.Data
{
    public class ApplicationData : IApplicationData //Change
    {
        private IApplicationDbContext context; //Change
        private IDictionary<Type, object> repositories;

        public ApplicationData()
            : this(new ApplicationDbContext()) //Change
        {
        }

        public ApplicationData(IApplicationDbContext context) //Change
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<UserProfile> UserProfiles //Change
        {
            get
            {
                return this.GetRepository<UserProfile>(); //Change
            }
        }

        public IRepository<ApplicationUser> Users //Change
        {
            get
            {
                return this.GetRepository<ApplicationUser>(); //Change
            }
        }

        //public IRepository<Song> Songs //Change
        //{
        //    get
        //    {
        //        return this.GetRepository<Song>(); //Change
        //    }
        //}

        //public StudentsRepository Students //Change
        //{
        //    get
        //    {
        //        return (StudentsRepository)this.GetRepository<Student>(); //Change
        //    }
        //}

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                //if (typeOfModel.IsAssignableFrom(typeof(Student)))
                //{
                //    type = typeof(StudentsRepository);
                //}

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
