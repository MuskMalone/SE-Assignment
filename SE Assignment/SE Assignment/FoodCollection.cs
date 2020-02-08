using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class FoodCollection : FoodIterator
    {
        public List<Food> foodList = new List<Food>();
        public int position = 0;

        public Food NextFood()
        {
            if (position < foodList.Count)
            {
                position++;
                return foodList[position];
            }
            return null;
        }

        public bool HasNextFood()
        {
            if (position < foodList.Count)
                return true;
            return false;
        }

        public void AddFood(Food f)
        {
            foodList.Add(f);
        }

        public void RemoveFood(Food f)
        {
            foodList.RemoveAt(position);
        }
    }
}
