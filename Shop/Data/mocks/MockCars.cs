using Premium.Data.interfaces;
using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Premium.Data.mocks
{
    public class MockCars : IALLCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car> {
                    new Car {
                        name = "Toyota Prius 20",
                        shortDesc = "Linistit si simplu",
                        longDesc = "Simplu si linistit automobil pentru a face comenzi",
                        img = "/img/20.png",
                        price =450,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.ALLCategories.First()
                    },
                    new Car {
                        name = "Toyota Prius 30",
                        shortDesc = "Linistit si simplu",
                        longDesc = "Convenabil pentru viata de la oras",
                        img = "/img/30.png",
                        price = 550,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.ALLCategories.Last()
                    },
                    new Car {
                        name = "Toyota Prius +",
                        shortDesc = "Automobil rapid",
                        longDesc = "Rapid,convenabil in oras",
                        img = "/img/45.jpg",
                        price = 600,
                        isFavorite = true,
                        available = true,
                        Category = _categoryCars.ALLCategories.Last()
                    },
                    new Car {
                        name = "Renault Scenic",
                        shortDesc = "Automobil rapid",
                        longDesc = "Rapid, bun concurent al priusului +",
                        img = "/img/renault.png",
                        price = 550,
                        isFavorite = false,
                        available = false,
                        Category = _categoryCars.ALLCategories.Last()
                    },
                    new Car {
                        name = "Skoda fabia",
                        shortDesc = "Automobil rapid",
                        longDesc = "Rapid",
                        img = "/img/fabia.png",
                        price = 350,
                        isFavorite = false,
                        available = false,
                        Category = _categoryCars.ALLCategories.Last()
                    }

                };
            }

        } 
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
