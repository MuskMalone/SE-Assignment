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
            /*Order o1 = new Order(1, "new");
            Order o2 = new Order(2, "preparing");
            Order o3 = new Order(3, "new");
            Order o4 = new Order(4, "preparing");
            AddOrder(o1);
            AddOrder(o2);
            AddOrder(o3);
            AddOrder(o4);*/
        }
        public void AddOrder(Order o)
        {
            OrderList.Add(o);
        }
        public bool HasNextOrder()
        {

            if (position < OrderList.Count() - 1)
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
        public Order CurrentOrder()
        {
            if (position < OrderList.Count())
            {
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
                    //Console.WriteLine(i);
                    return OrderList[i];
                }
            }
            return null;
        }

        public List<Order> GetAllOrdersWhereState(string state)
        {
            List<Order> oL = new List<Order>();
            for (int i = 0; i < OrderList.Count(); i++)
            {
                if (OrderList[i].OrderStatus == state)
                {
                    oL.Add(OrderList[i]);
                }
            }
            return oL;
        }
        
        /*
        public List<Order> GetAllOrdersState()
        {
            List<Order> oList = new List<Order>();
            for (int i = 0; i < OrderList.Count(); i++)
            {
                if (OrderList[i].OrderStatus == "new" || 
                    OrderList[i].OrderStatus == "ready" ||
                    OrderList[i].OrderStatus == "preparing" || 
                    OrderList[i].OrderStatus == "dispatched" ||
                    OrderList[i].OrderStatus == "delivered")
                {
                    oList.Add(OrderList[i]);
                }
            }
            return oList;
        }
        */
    }
}
