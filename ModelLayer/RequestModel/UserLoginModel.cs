using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.RequestModel
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(8, ErrorMessage = "Enter password with a minimum length of 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Enter a valid Password")]
        [DefaultValue("name@123")]
        public string? Password { get; set; }
    }
}
