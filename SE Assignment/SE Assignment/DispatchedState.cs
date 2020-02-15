using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class DispatchedState : OrderState
    {
        private string name = "dispatched";

        private Order myOrder;

        public DispatchedState(Order order)
        {
            myOrder = order;
        }
        public string getStateName()
        {
            return name;
        }

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
            Console.WriteLine("Order has already been dispatched");
        }

        public void confirmOrder()
        {
            Console.WriteLine("Order has been received");
            myOrder.setState(myOrder.getDeliveredState());
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order has been cancelled");
        }
    }
}
