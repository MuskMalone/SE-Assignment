using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Food
    {
        private string title;
        private string category;
        private double price;
        //private string set;

        public string Title { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        //public string Set { get; set; }

        public Food(string t, string c, double p)
        {
            title = t;
            category = c;
            price = p;
        }
    }
}
