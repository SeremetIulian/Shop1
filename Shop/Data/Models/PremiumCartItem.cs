using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.Models
{
    public class PremiumCartItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public int price { get; set; }

        public string PremiumCartId { get; set; }
        
    }
}
