using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Home.Auth.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The user name field is required")]
        [Display(Name = "User name", Prompt = "User name place")]
        public string UserName { get; set; }

        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Email place")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [StringLength(100, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password place")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm password place")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
