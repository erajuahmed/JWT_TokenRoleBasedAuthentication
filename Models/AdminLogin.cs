using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_TokenRoleBasedAuthentication.Models
{
    public class AdminLogin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        [Display(Name = "User Name")]
        [StringLength(100)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [StringLength(100)]
        public string Password { get; set; }

        public int RoleId { get; set; }         
        public Role Role { get; set; }

    }
}
