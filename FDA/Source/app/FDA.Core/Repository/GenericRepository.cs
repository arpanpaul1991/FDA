using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDA.Core.DBContext;
using System.Linq.Expressions;

namespace FDA.Core.Repository
{
    public class GenericRepository<T> where T : class
    {

        internal DatabaseContext dataBaseContext;
        internal DbSet<T> DbSet;

        public GenericRepository(DatabaseContext database)
        {
            this.dataBaseContext = database;
            this.DbSet = database.Set<T>();

        }
        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = DbSet;

            foreach (var item in include)
            {
                query = query.Include(item);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public void Update(T entity)
        {
            dataBaseContext.Entry(entity).State = EntityState.Modified;

        }
        public void Save()
        {

            dataBaseContext.SaveChanges();

        }
        public void Insert(T entity)
        {
            this.DbSet.Add(entity);

        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            this.DbSet.Remove(entity);
        }


    }
}
