using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }

    }
}
