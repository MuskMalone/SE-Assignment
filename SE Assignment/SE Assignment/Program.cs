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
            //pushing
            OrderCollection oc = new OrderCollection();
            Chef c = new Chef("bob", 1, "zzz", 'M', DateTime.UtcNow, "yes", oc);
            Order o1 = new Order(1, "new");
            Order o2 = new Order(2, "preparing");
            Order o3 = new Order(3, "new");
            Order o4 = new Order(4, "preparing");
            oc.AddOrder(o1);
            oc.AddOrder(o2);
            oc.AddOrder(o3);
            oc.AddOrder(o4);
            Console.WriteLine(oc.GetOrder(1).OrderStatus);
            Console.WriteLine(oc.HasNextOrder().ToString());
            while (oc.HasNextOrder())
            {
                Order o = oc.GetNextOrderWhereState("preparing");
                
                Console.WriteLine(oc.GetNextOrderWhereState("preparing").OrderStatus);
                if (o == null) { break; }
            }
        }
    }
}
