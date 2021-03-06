﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class PreparingState : OrderState
    {
        private string name = "preparing";
        private Order myOrder;

        public string getStateName()
        {
            return name;
        }
        public PreparingState(Order order)
        {
            myOrder = order;
        }
        
        public void prepareOrder()
        {
            Console.WriteLine("Order preparation has already started!");
        }

        public void completeOrder()
        {
            Console.WriteLine("Order is ready");
            myOrder.setState(myOrder.getReadyState());
            // Code

        }

        public void dispatchOrder()
        {
            Console.WriteLine("You can't dispatch the order, you haven't finished preparing it yet!");
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
