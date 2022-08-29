using SweetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.DAL.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetByLoginAsync(string login);
    }
}

