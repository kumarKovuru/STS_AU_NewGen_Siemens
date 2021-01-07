using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STS_AU_NewGen_Siemens
{
    public class Gold
    {
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal Discount { get; set; }

        public Decimal TotalPrice => (Price * Weight) - (((Price * Weight) / 100) * Discount);
    }
}
