using CarsAndDrivers.Data.Common.Repository;
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

        //public IRepository<Album> Albums //Change
        //{
        //    get
        //    {
        //        return this.GetRepository<Album>(); //Change
        //    }
        //}

        //public IRepository<Artist> Artists //Change
        //{
        //    get
        //    {
        //        return this.GetRepository<Artist>(); //Change
        //    }
        //}

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
    }
}
