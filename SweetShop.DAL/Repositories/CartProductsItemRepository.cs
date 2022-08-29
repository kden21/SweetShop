using Microsoft.EntityFrameworkCore;
using SweetShop.Domain;
using SweetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.DAL.Repositories
{
    public class CartProductsItemRepository
    {
        public readonly SweetShopContext _context;
        public CartProductsItemRepository(SweetShopContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(CartProductItem entity)
        {
            entity.Product = _context.Products.FirstOrDefault(x => x.Id == entity.ProductId);
            var cart = await _context.CartProductItems.Where(x => x.CartProductsId == entity.CartProductsId).Where(x => x.Product.Name == entity.Product.Name).ToListAsync();
            if (cart!=null) 
            {
                cart[0].Count += entity.Count;
                //var item = cart.CartProductItems.FirstOrDefault(x => x.Product.Name == entity.Product.Name);
                //item.Count+=entity.Count;
            }
            else
            {
               
                entity.CartProducts = _context.CartsProducts.FirstOrDefault(x => x.Id == entity.CartProductsId);
                entity.Price = entity.Product.Price;
                //entity.
                await _context.CartProductItems.AddAsync(entity);
            }
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(CartProductItem entity)
        {
            //var entity = _context.CartProductItems.FirstOrDefault(x=>x.Id==id);
            _context.CartProductItems.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<CartProductItem> GetAsync(int id)
        {
            return await _context.CartProductItems.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
