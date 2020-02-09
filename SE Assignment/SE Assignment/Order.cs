using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Order
    {
        private string orderStatus;
        public String OrderStatus { get; set; }
        public readonly int OrderID;

        public Order(int id, string status) //status should be removed 
        {
            OrderID = id;
            OrderStatus = status;
            //OrderStatus = "new";

        }

        public void registerCustomer()
        {
            Console.WriteLine("");
            // Code
        }

        public void removeCustomer()
        {
            Console.WriteLine("");
            // Code
        }

        public void notifyCustomer()
        {
            Console.WriteLine("");
            // Code
        }


        public Order()
        {
        }
    }
}
