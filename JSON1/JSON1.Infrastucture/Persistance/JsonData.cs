using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSON1.Domain.Entities;

namespace JSON1.Infrastucture.Persistance
{
    public class JsonData
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }

}
