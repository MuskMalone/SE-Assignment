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

        public int MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public FoodCollection(int id, string menuName)
        {
            menuID = id;
            name = menuName;
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

        public void editFood(int id, Food f)
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
            for (int i = 0; i < size-1; i++)
            {
                if (foodList[i].FoodID == id)
                {
                    foodList.RemoveAt(i);
                    size -= 1;
                    Console.WriteLine("Successfully Deleted "+foodList[i].Title+"!");
                }
            }
        }
    }
}
