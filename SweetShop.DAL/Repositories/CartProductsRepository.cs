using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SweetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.DAL.Repositories
{
    public class CartProductsRepository
    {
        public readonly SweetShopContext _context;
        public CartProductsRepository(SweetShopContext context)
        {
            _context=context;
        }
        public async Task<CartProducts?> GetCart(int id)
        {
            return await _context.CartsProducts.Include(a=>a.CartProductItems).ThenInclude(a=>a.Product).FirstOrDefaultAsync(x => x.Id == id);
        }
        /*public async Task<bool> AddItemInCartProducts(CartProductItem entity)
        {
            await _context.CartsProducts.car
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddItemInCartProducts(Cart entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }*/
    }
}
