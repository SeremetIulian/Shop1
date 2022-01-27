using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {



            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                      new Car
                      {
                          name = "Toyota Prius 20",
                          shortDesc = "Linistit si simplu",
                          longDesc = "Simplu si linistit automobil pentru a face comenzi",
                          img = "/img/20.png",
                          price = 450,
                          isFavorite = true,
                          available = true,
                          Category = Categories["Masini hibrid"]
                      },
                    new Car
                    {
                        name = "Toyota Prius 30",
                        shortDesc = "Linistit si simplu",
                        longDesc = "Convenabil pentru viata de la oras",
                        img = "/img/30.png",
                        price = 550,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Masini hibrid"]
                    },
                    new Car
                    {
                        name = "Toyota Prius +",
                        shortDesc = "Automobil rapid",
                        longDesc = "Rapid",
                        img = "/img/BMW M3.jpg",
                        price = 600,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Masini hibrid"]
                    },
                    new Car
                    {
                        name = "Renaul scenic",
                        shortDesc = "Automobil rapid",
                        longDesc = "Econom",
                        img = "/img/renault.png",
                        price = 550,
                        isFavorite = false,
                        available = false,
                        Category = Categories["Masini clasice"]
                    },
                    new Car
                    {
                        name = "Scoda fabia",
                        shortDesc = "Automobil rapid",
                        longDesc = "Manevrabil",
                        img = "/img/fabia.png",
                        price = 350,
                        isFavorite = false,
                        available = false,
                        Category = Categories["Masini clasice"]
                    }
                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary <string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Masini hibrid", desc = "Cel mai actual tip de transport"},
                        new Category { categoryName = "Masini clasice", desc = "Masini cu motor cu ardere interna"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);

                }

                return category;
            }
        }
    }
}
