using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.Models
{
    public class PremiumCart
    {
        private readonly AppDBContent appDBContent;
        public PremiumCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string PremiumCartId { get; set; }
        public List<PremiumCartItem> listPremiumCarItems { get; set; }

        public static PremiumCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string premiumCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", premiumCartId);
            return new PremiumCart(context) { PremiumCartId = premiumCartId };
        }

        public void AddToCart(Car car)
        {
            this.appDBContent.PremiumCartItems.Add(new PremiumCartItem
            {
                PremiumCartId = PremiumCartId,
                car = car,
                price = car.price
            });
         appDBContent.SaveChanges();
        }
        public List<PremiumCartItem> GetPremiumItems()
        {
            return appDBContent.PremiumCartItems.Where(c => c.PremiumCartId == PremiumCartId).Include(s => s.car).ToList();
        }
    } 
}
