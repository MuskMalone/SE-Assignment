﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class DeliveredState: OrderState
    {
        private string name = "delivered";
        private Order myOrder;

        public DeliveredState(Order order)
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
            Console.WriteLine("Order has already been received");
        }

        public void archiveOrder()
        {
            Console.WriteLine("Order has been archived");
        }

        public void cancelOrder()
        {
            Console.WriteLine("Your order has already been delivered");
        }
    }
}
