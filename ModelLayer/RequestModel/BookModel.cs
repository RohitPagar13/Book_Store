using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.RequestModel
{
    public class BookModel
    {

        [DefaultValue("Title")]
        public string Title { get; set; }

        [DefaultValue("Author")]
        public string Author { get; set; }

        [DefaultValue("ISBN")]
        public string ISBN { get; set; }

        [DefaultValue("Genre")]
        public string Genre { get; set; }

        [DefaultValue("Publisher")]
        public string Publisher { get; set; }
        public string Description { get; set; } = string.Empty;

        [RegularExpression("^/d+(/./d{1,2})?$")]
        [DefaultValue(00.00)]
        public double Price { get; set; }

        [RegularExpression("^/d$")]
        [DefaultValue(0)]
        public int StockQuantity { get; set; }
    }
}
