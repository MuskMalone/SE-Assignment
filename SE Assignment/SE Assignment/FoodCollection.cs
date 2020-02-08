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

        public Food GetCurrent()
        {
            return foodList[position];
        }

        public Food NextFood()
        {
            if (position < foodList.Count()-1)
            {
                position++;
                return foodList[position];
            }
            return null;
        }

        public bool HasNextFood()
        {
            if (position < foodList.Count()-1)
                return true;
            return false;
        }

        public void AddFood(Food f)
        {
            foodList.Add(f);
            Console.WriteLine(f.Title+" Added Successfully!");
        }

        public void editFood(int id, Food f)
        {
            for (int i = 0; i < foodList.Count()-1; i++)
            {
                if (foodList[i].FoodID == id)
                {
                    foodList[i] = f;
                    Console.WriteLine("Successfully Edited Food Item!");
                }
            }
        }

        public void RemoveFood(int id)
        {
            for (int i = 0; i < foodList.Count() - 1; i++)
            {
                if (foodList[i].FoodID == id)
                {
                    foodList.RemoveAt(i);
                    Console.WriteLine("Successfully Deleted Food Item!");
                }
            }
        }
    }
}
