using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Users
    {   
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual ICollection<Roles> Role { get; set; }

        public Users()
        {
            this.Role = new List<Roles>();
        }
    }
}
