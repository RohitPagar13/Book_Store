using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId {  get; set; }

        [ForeignKey("UserDetailsEntity")]
        [Required]
        public int UserDetailsEntityId { get; set; }

        public UserDetailsEntity UserDetails { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
         
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public double TotalOrderPrice { get; set; }
    }
}
