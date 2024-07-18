using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [ForeignKey("BookEntity")]
        public int BookId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; } 

        [Range(0.01, double.MaxValue, ErrorMessage = "CartPrice must be greater than 0.00.")]
        public double CartPrice {  get; set; }

        public bool IsInStock { get; set; }

        [ForeignKey("UserEntity")]
        public int UserId {  get; set; }

    }
}
