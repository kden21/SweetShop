using Microsoft.EntityFrameworkCore;
using SweetShop.DAL.Interfaces;
using SweetShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly SweetShopContext _context;
        public ProductRepository(SweetShopContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Product>> SelectAsync()
        {
            return await _context.Products.ToListAsync();
        }

		public async Task<Product> Update(Product entity)
		{
			_context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
		}
	}
}
