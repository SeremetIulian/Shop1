using Microsoft.AspNetCore.Mvc;
using Premium.Data.interfaces;
using Premium.Data.Models;
using Premium.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Premium.Controllers
{
    public class CarsController : Controller {

        private readonly IALLCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IALLCars iALLCars, ICarsCategory iCarsCat)
        {
            _allCars = iALLCars;
            _allCategories = iCarsCat;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{Category}")]
        public  ViewResult List (string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Masini electrice")).OrderBy(i => i.id);
                    currCategory = "Masini electrice";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Masini clasice")).OrderBy(i => i.id);
                    currCategory = "Masini clasice";

                }

                currCategory = _category;

                
            }
            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = currCategory
            };




            ViewBag.Title = "Pagina cu masini";
            
            return View(carObj);
        }
    }
}
