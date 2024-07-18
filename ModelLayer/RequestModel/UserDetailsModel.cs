using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.RequestModel
{
    public class UserDetailsModel
    {
        [DefaultValue("Home/Work/Other")]
        public string? AddressType { get; set; }

        [Required]
        [DefaultValue("AddressLine")]
        public string? AddressLine { get; set; }

        [DefaultValue("Near to Church-Gate")]
        public string? LandMark { get; set; }

        [Required]
        [DefaultValue("City")]
        public string? City { get; set; }

        [Required]
        [DefaultValue("Country")]
        public string? Country { get; set; }

        [Required]
        [DefaultValue("ZipCode")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "ZipCode must be exactly 6 digits.")]
        public int ZipCode { get; set; }
    }
}
