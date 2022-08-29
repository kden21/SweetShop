using SweetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public string? CountryProducing { get; set; }
        //public int PurchaseItemId { get; set; };
        //public PurchaseItem? PurchaseItem { get; set; }
        public List<CartProductItem> CartProductItems { get; set; } = new();
    }
}
