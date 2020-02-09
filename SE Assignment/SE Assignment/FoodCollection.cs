using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class FoodCollection : FoodIterator
    {
        private int menuID;
        private string name;
        private int size = 0;

        public FoodCollection(int id, string menuName)
        {
            menuID = id;
            name = menuName;
        }

        public int GetID()
        {
            return menuID;
        }
        public string GetName()
        {
            return name;
        }

        List<Food> foodList = new List<Food>();
        int position = 0;

        public Food GetCurrent()
        {
            return foodList[position];
        }

        public Food NextFood()
        {
            if (position < size-1)
            {
                position++;
                return foodList[position];
            }
            position = 0;
            return null;
        }

        public bool HasNextFood()
        {
            if (position < size-1)
                return true;
            position = 0;
            return false;
        }

        public void AddFood(Food f)
        {
            foodList.Add(f);
            size += 1;
            Console.WriteLine(f.Title+" Added Successfully!");
        }

        public void EditFood(int id, Food f)
        {
            for (int i = 0; i < size-1; i++)
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
            for (int i = 0; i < size; i++)
            {
                if (foodList[i].FoodID == id)
                {
                    string removedFood = foodList[i].Title;
                    foodList.RemoveAt(i);
                    size -= 1;
                    Console.WriteLine("Successfully Deleted " + removedFood + "!");
                }
            }
        }

        public override string ToString()
        {
            return "Menu " + menuID + ": " + name + ", Size: " + size;
        }
    }
}
