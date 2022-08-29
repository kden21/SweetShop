using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SweetShop.DAL.SweetShopContext

namespace SweetShop.Domain.Entities
{
    public class CartProducts
    {
        //public readonly SweetShopContext _context;
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        //public int CartProductItemId { get; set; }//
        
        public List<CartProductItem> CartProductItems { get; set; } = new();
        public decimal? Result()
        {
            decimal? result = 0;
            foreach (CartProductItem item in CartProductItems)
            {
                result += item.ProductPrice();
            }
            return result;
        }
    }
}
