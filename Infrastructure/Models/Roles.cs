using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required]
		[MaxLength(10)]
        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public virtual ICollection<Users> Users { get; set; }

        public Roles()
        { 
			this.Users = new List<Users>();
        }
    }
}
