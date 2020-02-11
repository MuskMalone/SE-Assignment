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
            Console.WriteLine("========= new owdews UwU ========\n");
            List<Order> oL = ordercollection.GetAllOrdersWhereState("new");
            for (int i = 0; i < oL.Count(); i++)
            {
                Console.WriteLine(oL[i].OrderID + "      " + oL[i].getCurrentState().getStateName());
            }
        }
        public void GetAllPreparingOrders()
        {
            Console.WriteLine("\n");
            Console.WriteLine("========= pwepawing owdews OwO ========\n");
            List<Order> oL = ordercollection.GetAllOrdersWhereState("preparing");
            for (int i = 0; i < oL.Count(); i++)
            {
                Console.WriteLine(oL[i].OrderID + "      " + oL[i].getCurrentState().getStateName());
            }
        }
        public void PrepareOrder(int orderid)
        {
            ordercollection.GetOrder(orderid).getCurrentState().prepareOrder();
        }
        public void CompleteOrder(int orderid)
        {
            ordercollection.GetOrder(orderid).getCurrentState().completeOrder();
        }
    }
}
