using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        DbContext context;
        protected DbSet<T> table;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            table=context.Set<T>();
        }

        public T Add(T entity)
        {
            table.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            table.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public T Delete(T entity)
        {
            table.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public T Get(Guid id)
        {
            return table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }

        public Task<T> GetAsync(Guid id)
        {
            return Task.Run(() =>
            {
                return Get(id);
            });
        }

        public async Task<T> RemoveAsync(T entity)
        {
            table.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State= EntityState.Modified;
            context.SaveChanges();
        }

        public async void UpdateAsync(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
