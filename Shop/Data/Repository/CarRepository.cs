using Microsoft.EntityFrameworkCore;
using Premium.Data.interfaces;
using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.Repository
{
    public class CarRepository : IALLCars
    {

        private readonly AppDBContent appDBContent;
        public CarRepository (AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);
        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavorite).Include(c => c.Category);

        public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);
        
    }
}
