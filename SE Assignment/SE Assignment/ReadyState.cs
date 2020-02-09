using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class ReadyState : OrderState
    {
        /*private Order myOrder;

        public ReadyState(Order order)
        {
            myOrder = order;
        }*/

        public void prepareOrder()
        {
            Console.WriteLine("Order preparation has already started!");
        }

        public void completeOrder()
        {
            Console.WriteLine("Order already complete!");
        }

        public void dispatchOrder()
        {
            Console.WriteLine("Order has been dispatched");
            // Code
        }

        public void confirmOrder()
        {
            Console.WriteLine("Order can't be confirmed, it hasn't been dispatched!");
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order has been cancelled");
            // Code
        }
    }
}
