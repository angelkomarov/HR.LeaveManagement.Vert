using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//!!AK2 - HR.LeaveManagement.Application is sitting between the application and the Database

//!!AK2.1 Define all Interfaces of our repositories - they use the Entities from Domain project.
//Generic repository for basic CRUD functions
namespace HR.LeaveManagement.Common.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync(); //IReadOnlyList<T> inherits IEnumerable<T>
        Task<bool> ExistsAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
