using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class UserDetailsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserDetailsId {  get; set; }
        public string? AddressType { get; set; }

        [Required]
        public string? AddressLine { get; set; }
        public string? LandMark { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public int ZipCode { get; set;}

        [Required]
        [ForeignKey("UserEntity")]
        public int UserId { get; set; }

    }
}
