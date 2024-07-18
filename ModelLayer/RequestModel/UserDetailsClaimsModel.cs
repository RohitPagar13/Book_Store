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
    public class UserDetailsClaimsModel
    {
        public string? AddressType { get; set; }

        public string? AddressLine { get; set; }

        public string? LandMark { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public int ZipCode { get; set; }

        public int UserId {  get; set; }
    }
}
