using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Food
    {
        private int foodID;
        private string title;
        private string category;
        private double price;
        private string status;

        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public Food(int id, string _title, string _category, double _price, string _status)
        {
            foodID = id;
            title = _title;
            category = _category;
            price = _price;
            status = _status;
        }

        public override string ToString()
        {
            return "Food " + foodID + ": " + title + ", Category: " + category + ", Price: " + price;
        }
    }
}
