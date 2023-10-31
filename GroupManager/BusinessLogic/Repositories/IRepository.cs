using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IRepository<T> where T:class
    {
        T Add(T entity);
        void Update(T entity);
        T Delete(T entity);
        T Get(Guid id);
        Task<T> RemoveAsync(T entity);
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        IQueryable<T> GetAll();
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);

        
    }
}
