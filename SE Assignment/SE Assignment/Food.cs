using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Food
    {
        private string name;
        private double price;
        // Get Set
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }

        public Food() { }

        public Food(string _name, double _price)
        {
            name = _name;
            price = _price;
        }

        public override string ToString()
        {
            return name + " - $" + price;
        }

    }
}
