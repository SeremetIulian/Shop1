using Premium.Data.interfaces;
using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly PremiumCart premiumCart;
        
        public OrdersRepository (AppDBContent appDBContent, PremiumCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.premiumCart = shopCart;
        }
            
        public void createOrder(Order order) 
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();


            var items = premiumCart.listPremiumCarItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carID = el.car.id,
                    orderID = order.id,
                    price = (uint)el.car.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
                
            }
            appDBContent.SaveChanges();
        }
       
    }
}
