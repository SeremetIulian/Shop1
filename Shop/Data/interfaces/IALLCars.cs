using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.interfaces
{
     public  interface IALLCars
    {
        IEnumerable<Car> Cars { get;  }
        IEnumerable<Car> getFavCars { get;  }
        Car getObjectCar(int carId);
    }
}
