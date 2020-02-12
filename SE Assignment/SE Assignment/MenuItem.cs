using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class MenuItem
    {
        private int itemID;
        private string name;
        private double price;
        private List<Product> foodList = new List<Product>();
        // Get Set
        public int ItemID { get { return itemID; } set { itemID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public List<Product> FoodList { get { return foodList; } set { foodList = value; } }

        public MenuItem() { }

        public MenuItem(int _itemID, string _name, double _price)
        {
            itemID = _itemID;
            name = _name;
            price = _price;
        }


        public override string ToString()
        {
            string stringToToString = "";
            if (foodList.Count() > 1)
            {
                stringToToString += "[" + itemID + "] " + name + " - $" + price + "\n";
                foreach (Product p in foodList)
                {
                    stringToToString += "   > " + p.Title + "\n";
                }
            }
            else
                stringToToString += foodList[0].ToString() + "\n";

            return stringToToString;
        }
    }
}
