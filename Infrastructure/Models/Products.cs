using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int QuantityPerUnit { get; set; }

        public int UnitPrice { get; set; }

        public int UnitsInStocks { get; set; }

        public int UnitsOnOrders { get; set; }

        public int Discounted { get; set; }

        public virtual Category Category { get; set; }

        public virtual Suppliers Suppliers { get; set; }
    }
}
