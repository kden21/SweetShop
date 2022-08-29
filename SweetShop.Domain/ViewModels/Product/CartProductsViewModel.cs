using SweetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Domain.ViewModels.Product
{
    public class CartProductsViewModel
    {
        public int Id { get; set; }
        public List<CartProductItem> CartProductItems { get; set; } = new();
        public double Sum { get; set; }

    }
}
