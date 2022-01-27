using Microsoft.AspNetCore.Mvc;
using Premium.Data.interfaces;
using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Controllers
{
    public class OrderController:Controller
    {
        private readonly IAllOrders allOrders;
        private readonly PremiumCart shopCart;

        public OrderController(IAllOrders allOrders, PremiumCart shopCart)
        {
            this.allOrders=allOrders;
            this.shopCart = shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listPremiumCarItems = shopCart.GetPremiumItems();

            if(shopCart.listPremiumCarItems.Count == 0) {
                ModelState.AddModelError("", "Trebue sa aveti careva masina");
                    }
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Comanda este facuta cu sicces";
            return View();
        }
    }
}
