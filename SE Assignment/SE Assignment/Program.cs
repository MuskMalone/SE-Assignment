using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderCollection oc = new OrderCollection();
            Chef chef = new Chef("coom", 1, "zzz", 'm', DateTime.UtcNow, "Active", oc);

            Console.WriteLine(chef.getOrderCollection().GetOrder(1).OrderStatus);
            chef.getOrderCollection().GetOrder(1).getCurrentState().prepareOrder();
            Console.WriteLine(chef.getOrderCollection().GetOrder(1).OrderStatus);
            chef.getOrderCollection().GetOrder(1).getCurrentState().completeOrder();
            Console.WriteLine(chef.getOrderCollection().GetOrder(1).OrderStatus);
            Console.ReadLine();
        }
    }
}
