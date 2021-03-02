using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace FleetManagementService.Models.Repositories
{
    public class Repository<T> where T : class
    {
        private FMSDataContext context = null;
        protected DbSet<T> DbSet
        {
            get; set;
        }

        public Repository()
        {
            context = new FMSDataContext();
            DbSet = context.Set<T>();
        }

        public Repository(FMSDataContext context)
        {
            this.context = context;
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}