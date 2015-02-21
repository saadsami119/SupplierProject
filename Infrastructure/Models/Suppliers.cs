using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        public string ContractName { get; set; }
        public string ContractTitle { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string WebsiteURL { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
