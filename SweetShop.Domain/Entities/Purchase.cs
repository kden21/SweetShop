using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public bool PurchasePayment { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Sum { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
