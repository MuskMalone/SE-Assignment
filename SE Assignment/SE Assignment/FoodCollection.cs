using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class FoodCollection : FoodIterator
    {        
        public List<MenuItem> itemList = new List<MenuItem>();
        int position = 0;

        public MenuItem GetCurrent()
        {
            return itemList[position];
        }

        public MenuItem NextFood()
        {
            if (position < itemList.Count()-1)
            {
                position++;
                return itemList[position];
            }
            position = 0;
            return null;
        }

        public bool HasNextFood()
        {
            if (position < itemList.Count()-1)
                return true;
            position = 0;
            return false;
        }

        public void AddFood(MenuItem m)
        {
            itemList.Add(m);
            Console.WriteLine(m.Name +" Added Successfully!");
        }

        public void RemoveFood(int id)
        {
            for (int i = 0; i < itemList.Count(); i++)
            {
                if (itemList[i].ItemID == id)
                {
                    string removedFood = itemList[i].Name;
                    itemList.RemoveAt(i);
                    Console.WriteLine("Successfully Deleted " + removedFood + "!");
                }
            }
        }

        public MenuItem GetMenuItem(int id)
        {
            for (int i = 0; i < itemList.Count(); i++)
            {
                if (itemList[i].ItemID == id)
                {
                    return itemList[i];
                }
            }
            return null;
        }
    }
}
