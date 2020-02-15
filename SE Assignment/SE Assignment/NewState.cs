using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class NewState : OrderState
    {
        private string name = "new";
        private Order myOrder;

        public NewState(Order order)
        {
            myOrder = order;
        }
        public string getStateName()
        {
            return name;
        }

        public void prepareOrder()
        {
            Console.WriteLine("Order preparation has started");
            myOrder.setState(myOrder.getPreparingState());
            // Code
        }

        public void completeOrder()
        {
            Console.WriteLine("You can't complete the order, you haven't started preparing it yet!");
        }

        public void dispatchOrder()
        {
            Console.WriteLine("You can't dispatch the order, you haven't started preparing it yet!");
        }

        public void confirmOrder()
        {
            Console.WriteLine("Order can't be confirmed, it hasn't been dispatched!");
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order has been archived");
        }

        public void cancelOrder()
        {
            myOrder.setState(myOrder.getCancelledState());
            Console.WriteLine("Your order has been cancelled");
        }
    }
}
