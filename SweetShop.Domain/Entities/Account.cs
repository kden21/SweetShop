using Microsoft.AspNet.Identity.EntityFramework;
using SweetShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Domain.Entities
{
    public class Account 
    {
        public int Id { get; set; }
        //public string? Name { get; set; } 
        //public string? Surname { get; set; }
        //public int? Age { get; set; }
        //public int IdentityUserLoginId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public List<Purchase>? Purchases { get; set; } = new();
        //public int CartProductsId { get; set; }
        public CartProducts? CartProducts { get; set; }
    }
}
