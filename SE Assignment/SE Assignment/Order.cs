using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Order
    {
        public string OrderStatus;
        public readonly int OrderID;

        public Order(int id, string status) //status should be removed 
        {
            OrderID = id;
            OrderStatus = status;
            //OrderStatus = "new";

        }
    }
}
