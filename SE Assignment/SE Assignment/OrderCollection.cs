using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class OrderCollection
    {
        private List<Order> OrderList = new List<Order>();
        private int position = 0;
        public OrderCollection()
        {

        }
        public void AddOrder(Order o)
        {
            OrderList.Add(o);
        }
        public bool HasNextOrder()
        {
            if (position < OrderList.Count()-1)
            {
                return true;
            }
            return false;
        }
        public Order NextOrder()
        {
            if (position < OrderList.Count())
            {
                position++;
                Order o = OrderList[position];
                return o;
            }
            return null;
        }
        public Order GetOrder(int orderID)
        {
            for (int i = 0; i < OrderList.Count(); i++) 
            {
                Order o = OrderList[i];
                if (o.OrderID == orderID)
                {
                    return o;
                }
            }
            return null;
        }
        public Order GetNextOrderWhereState(string state)
        {
            for (int i = position+1; i < OrderList.Count(); i++)
            {
                if (OrderList[i].OrderStatus == state)
                {
                    position = i;
                    // Console.WriteLine(i);
                    return OrderList[i];
                }
            }
            return null;
        }
    }
}
