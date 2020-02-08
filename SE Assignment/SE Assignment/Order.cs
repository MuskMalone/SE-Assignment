using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Order : FoodAggregate
    {
        private string orderStatus;
        public String OrderStatus { get; set; }


        public FoodIterator CreateFoodIterator()
        {
            FoodIterator fi = new FoodCollection();
            return fi;
        }

        public void registerCustomer()
        {
            Console.WriteLine("");
            // Code
        }

        public void removeCustomer()
        {
            Console.WriteLine("");
            // Code
        }

        public void notifyCustomer()
        {
            Console.WriteLine("");
            // Code
        }


        public Order()
        {
        }
    }
}
