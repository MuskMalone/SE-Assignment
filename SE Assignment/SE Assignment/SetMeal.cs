using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class SetMeal : Product
    {
        private int size;

        public int Size { get { return size; } set { size = value; } }

        public SetMeal() { }
        public SetMeal(int id, string _title, string _description, string _category, double _price, string _unit, string _status, int _size)
        {
            foodID = id;
            title = _title;
            description = _description;
            category = _category;
            price = _price;
            unit = _unit;
            status = _status;
            size = _size;
        }
    }
}
