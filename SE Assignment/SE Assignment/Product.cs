using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Product
    {
        protected int foodID;
        protected string title;
        protected string description;
        protected string category;
        protected double price;
        protected string unit;
        protected string status;
       // Get Set
        public int FoodID { get { return foodID; } set { foodID = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Category { get { return category; } set { category = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public string Status { get { return status; } set { status = value; } }

        public Product() { }

        public Product(int id, string _title, string _description, string _category, double _price, string _unit, string _status)
        {
            foodID = id;
            title = _title;
            description = _description;
            category = _category;
            price = _price;
            unit = _unit;
            status = _status;
        }


    }
}
