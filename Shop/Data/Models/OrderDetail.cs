using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.Models
{
    public class OrderDetail
    {
        public int id { set; get; }
        public int orderID { set; get; }
        public int carID { set; get; }
        public uint price { set; get; }
        public  virtual Car car { set; get; }
        public virtual Order order { set; get; }
    }
}
