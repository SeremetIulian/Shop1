using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Premium.Data.Models;

namespace Premium.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currCategory { get; set;}
    }

}
