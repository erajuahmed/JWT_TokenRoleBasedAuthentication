using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_TokenRoleBasedAuthentication.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter role name")]
        [Display(Name = "Role Name")]
        [StringLength(100)]
        public string RoleName { get; set; }
        public ICollection<AdminLogin> AdminLogins { get; set; }


    }
}
