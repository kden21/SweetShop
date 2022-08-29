using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> CreateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<List<T>> SelectAsync();
        Task<bool> DeleteAsync(T entity);
        Task<T> Update(T entity);
    }
}
