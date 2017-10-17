using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        // To Do: 
        // 1. Enclose the _context in using {} to call dispose() -- done
        // 2. Return Ids of records added 

        // private CareerCloudContext _context;
        private bool _createProxy = true;

        public EFGenericRepository(bool createProxy = true)
        {
            _createProxy = createProxy;
           // _context = new CareerCloudContext(createProxy);
        }

        // return Ids of records added
        public void Add(params T[] items)
        {
            using (var context = new  CareerCloudContext(_createProxy))
                { 
                    foreach (var item in items)
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    context.SaveChanges();
                }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> result; 
            using (var context = new CareerCloudContext(_createProxy))
            {
                IQueryable<T> dbQuery = context.Set<T>();
                foreach (var navigationProperty in navigationProperties)
                {
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }
                result = dbQuery.ToList();
            }
            return result;
        }

        public IList<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> result;
            using (var context = new CareerCloudContext(_createProxy))
            {
                IQueryable<T> dbQuery = context.Set<T>();
                foreach (var navigationProperty in navigationProperties)
                {
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }
                result = dbQuery.AsNoTracking().Where(where).ToList<T>(); 
            }
            return result;
        }

        public T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            T result;
            using (var context = new CareerCloudContext(_createProxy))
            {
                IQueryable<T> dbQuery = context.Set<T>();
                foreach (var navigationProperty in navigationProperties)
                {
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }
                result = dbQuery.AsNoTracking().FirstOrDefault(where);
            }
            return result;
        }

        public void Remove(params T[] items)
        {
            using (var context = new CareerCloudContext(_createProxy))
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
            
        }

        public void Update(params T[] items)
        {
            using (var context = new CareerCloudContext(_createProxy))
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Modified;
                }
                context.SaveChanges();             
            }
        }
    }
}
