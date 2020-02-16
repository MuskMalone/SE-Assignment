using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Food
    {
        //private int foodID;
        private string name;
        private double price;
        // Get Set
        //public int FoodID { get { return foodID; } set { foodID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }

        public Food() { }

        public Food(string _name, double _price)
        {
            //foodID = id;
            name = _name;
            price = _price;
        }

        public override string ToString()
        {
            return name + " - $" + price;
        }

    }
}
