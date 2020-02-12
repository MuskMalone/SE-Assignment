using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Food : Product
    {
        public Food() { }
        public Food(int id, string _title, string _description, string _category, double _price, string _unit, string _status)
        {
            foodID = id;
            title = _title;
            description = _description;
            category = _category;
            price = _price;
            unit = _unit;
            status = _status;
        }


        public override string ToString()
        {
            return "[" + foodID + "] " + title + " (" + description + ") - $" + price
                    + "\nCategory: " + category + ", Unit: " + unit + ", Status:" + status;
        }
    }
}
