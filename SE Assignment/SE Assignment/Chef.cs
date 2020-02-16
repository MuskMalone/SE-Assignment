using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Chef : Employee
    {
        private OrderCollection ordercollection;

        public Chef() { }
        public Chef(string n, int id, string ic, char _gender, DateTime _datejoined, string _status, OrderCollection oc)
        {
            name = n;
            employeeID = id;
            nric = ic;
            gender = _gender;
            dateJoined = _datejoined;
            status = _status;
            ordercollection = oc;
        }

        public OrderCollection getOrderCollection() { return ordercollection; }
        
        public void GetAllNewOrders()
        {
            Console.WriteLine("\n");
            Console.WriteLine("========= New orders ========\n");
            List<Order> oL = ordercollection.GetAllOrdersWhereState("new");
            for (int i = 0; i < oL.Count(); i++)
            {
                Console.WriteLine(oL[i].displayOrderDetails());
            }
        }
        public void GetAllPreparingOrders()
        {
            Console.WriteLine("\n");
            Console.WriteLine("========= Orders in preparing state ========\n");
            List<Order> oL = ordercollection.GetAllOrdersWhereState("preparing");
            for (int i = 0; i < oL.Count(); i++)
            {
                Console.WriteLine(oL[i].displayOrderDetails());
            }
        }
        public void PrepareOrder(int orderid)
        {
            try
            {
                ordercollection.GetOrder(orderid).getCurrentState().prepareOrder();
            }
            catch(Exception e)
            {
                Console.WriteLine("Order does not exist");
            }
        }
        public void CompleteOrder(int orderid)
        {
            try
            {
                ordercollection.GetOrder(orderid).getCurrentState().completeOrder();
            }
            catch(Exception e)
            {
                Console.WriteLine("order does not exist");
            }

        }
    }
}
