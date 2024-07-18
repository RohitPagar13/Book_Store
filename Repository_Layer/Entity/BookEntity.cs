using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "BookPrice must be greater than 0.00.")]
        public double Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Stock Quantity must be greater than 0.")]
        public int StockQuantity { get; set; }

        [ForeignKey("BookEntity")]
        public int AdminId {  get; set; }
    }
}
