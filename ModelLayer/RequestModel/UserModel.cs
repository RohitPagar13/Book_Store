using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.RequestModel
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "Please Enter Valid First Name")]
        [DefaultValue("FirstName")]
        public string? FirstName { get; set; }

        [StringLength(50)]
        [DefaultValue("LastName")]
        public string? LastName { get; set; }


        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please Enter Phone number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter a valid Phone number")]
        [StringLength(14, ErrorMessage = "Phone number cannot be longer than 14 characters")]
        [DefaultValue("+910000000000")]
        public string? PhoneNo { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(8, ErrorMessage = "Enter password with a minimum length of 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Enter a valid Password")]
        [DefaultValue("name@123")]
        public string? Password { get; set; }

        [RegularExpression("^(Admin|Customer)$", ErrorMessage = "The role must be either 'Admin' or 'Customer'.")]
        public string? Role { get; set; }
    }
}
