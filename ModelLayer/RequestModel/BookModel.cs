using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.RequestModel
{
    public class BookModel
    {
        
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; } = string.Empty;

        [RegularExpression("^/d+(/./d{1,2})?$")]
        public double Price { get; set; }

        [RegularExpression("^/d$")]
        public int StockQuantity { get; set; }
    }
}
