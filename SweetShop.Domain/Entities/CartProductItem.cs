using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Domain.Entities
{
    public class CartProductItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int CartProductsId { get; set; }
        public CartProducts? CartProducts { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal? ProductPrice()
        {
            return Count * Price;
        }
    }
}
