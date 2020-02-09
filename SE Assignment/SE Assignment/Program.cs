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

            Console.WriteLine(oc.GetNextOrderWhereState("preparing").OrderID);
            Console.WriteLine(oc.GetNextOrderWhereState("preparing").OrderID);
            
            Console.ReadLine();
        }
    }
}
