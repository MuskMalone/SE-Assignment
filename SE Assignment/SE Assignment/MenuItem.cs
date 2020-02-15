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
        private string title;
        private string description;
        private string category;
        private double price;
        private string unit;
        private string status;
        private List<Food> foodList = new List<Food>();
        private bool isSetMenu;
        // Get Set
        public int ItemID { get { return itemID; } set { itemID = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Category { get { return category; } set { category = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public string Status { get { return status; } set { status = value; } }
        public List<Food> FoodList { get { return foodList; } set { foodList = value; } }
        public bool IsSetMenu { get { return isSetMenu; } set { isSetMenu = value; } }

        public MenuItem() { }

        public MenuItem(int id, string _title, string _description, string _category, double _price, string _unit, string _status, bool _isSetMenu)
        {
            itemID = id;
            title = _title;
            description = _description;
            category = _category;
            price = _price;
            unit = _unit;
            status = _status;
            isSetMenu = _isSetMenu;
        }

        public void addFood(Food f)
        {
            foodList.Add(f);
        }

        public int getSize()
        {
            return foodList.Count();
        }

        public void listFood()
        {
            for (int i = 0; i < foodList.Count(); i++)
            {
                Console.WriteLine("[" + (i+1) + "] " + foodList[i].ToString());
            }
        }

        public void removeFood(int id)
        {
            if (foodList[id - 1] != null)
            {
                foodList.RemoveAt(id - 1);
                Console.WriteLine("Successfully Removed!\n");
            }
        }

        public string NewToString(bool displayStatus)
        {
            string stringToToString = "";
            if (isSetMenu == true)
            {
                stringToToString += stringToToString += "[" + itemID + "] " + title + " (" + category + ") - $" + price + ", " +
                                    description + ", " + unit + ", Size: " + getSize();
                if (displayStatus)
                    stringToToString += " <" + status + ">\n";
                foreach (Food p in foodList)
                {
                    stringToToString += "   > " + p.Name + "\n";
                }
            }
            else
            {
                stringToToString += stringToToString += "[" + itemID + "] " + title + " (" + category + ") - $" + price + ", " +
                                    description + ", " + unit;
                if (displayStatus)
                    stringToToString += " <" + status + ">\n";
            }

            return stringToToString;
        }
    }
}
