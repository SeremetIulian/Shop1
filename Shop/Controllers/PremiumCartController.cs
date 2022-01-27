using Microsoft.AspNetCore.Mvc;
using Premium.Data.interfaces;
using Premium.Data.Models;
using Premium.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Controllers
{
    public class PremiumCartController : Controller
    {
        private readonly IALLCars _carRep;
        private readonly PremiumCart _premiumCart;

        public PremiumCartController (IALLCars carRep, PremiumCart shopCart)
        {
            _carRep = carRep;
            _premiumCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _premiumCart.GetPremiumItems();
            _premiumCart.listPremiumCarItems = items;


            var obj = new ViewModels.PremiumCartViewModel
            {
                premiumCart = _premiumCart
            };
            return View(obj);
        }
        public RedirectToActionResult addToCart (int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _premiumCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
