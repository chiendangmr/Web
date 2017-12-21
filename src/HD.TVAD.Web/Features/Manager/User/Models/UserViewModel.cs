using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Managers.User.Models
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public Guid id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        [Display(Name = "User name")]
        public string userName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Full name")]
        public string fullName { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Phone number")]
        public string phoneNumber { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }
    }
}
