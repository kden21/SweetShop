using Microsoft.EntityFrameworkCore;
using SweetShop.DAL.Interfaces;
using SweetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public readonly SweetShopContext _context;
        public AccountRepository(SweetShopContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Account entity)
        {
            //var user = new User();
            //await _context.Users.AddAsync(user);
            //await _context.SaveChangesAsync();
            //entity.User = user;
            //entity.UserId = user.Id;
            await _context.Accounts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Account entity)
        {
            _context.Accounts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Account> GetAsync(int id)
        {
            var account = await _context.Accounts.Where(a => a.Id == id).Include(a => a.User).Include(a=>a.Purchases).FirstOrDefaultAsync();
            return account;
        }

        public async Task<Account> GetByLoginAsync(string login)
        {

            return await _context.Accounts.FirstOrDefaultAsync(x => x.Username == login);
        }
        
        public async Task<List<Account>> SelectAsync()
        {
            //var us = _context.Users.Include(u=>u.Account).Where(u => u.Id == 1).ToList();
            /*var accounts = _context.Accounts.Where(a => a.Role == Domain.Enums.Role.User).Join(_context.Users,
                a=>a.UserId,
                u=>u.Id,
                (a, u) => new
                {
                    Name=u.Name,
                    Surname=u.Surname
                });*/
            var accounts = _context.Accounts.Where(a => a.Role == Domain.Enums.Role.User).Include(a=>a.User);          
            return await accounts.ToListAsync();
        }

        public async Task<Account> Update(Account entity)
        {
            _context.Accounts.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
