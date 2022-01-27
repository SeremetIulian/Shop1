using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.ViewModels
{
    public class PremiumCartViewModel
    {
        public PremiumCart premiumCart { get; set; }

        public static implicit operator PremiumCartViewModel(PremiumCart v)
        {
            throw new NotImplementedException();
        }
    }
}
