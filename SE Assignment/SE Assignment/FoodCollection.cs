using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class FoodCollection : FoodIterator
    {        
        List<MenuItem> itemList = new List<MenuItem>();
        int position = 0;

        public MenuItem GetCurrent()
        {
            if (itemList.Count() > 0)
                return itemList[position];
            else
                return null;
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
            Console.WriteLine(m.Title +" Added Successfully!\n");
        }

        public void RemoveFood(int id)
        {
            for (int i = 0; i < itemList.Count(); i++)
            {
                if (itemList[i].ItemID == id)
                {
                    string removedFood = itemList[i].Title;
                    cleanUpList(itemList[i]);   // Remove all other references to MenuItem
                    itemList.RemoveAt(i);
                    Console.WriteLine("Successfully Deleted " + removedFood + "!\n");
                }
            }
        }

        public void cleanUpList(MenuItem mi)
        {
            MenuItem currentFood = GetCurrent();
            if (currentFood.IsSetMenu == true)
            {
                for (int i = currentFood.getSize()-1; i > -1; i--)
                {
                    if (currentFood.FoodList[i] == mi.FoodList[0])
                    {
                        currentFood.FoodList.RemoveAt(i);
                        Console.WriteLine("Since " + mi.Title + " was deleted, it will be removed from " + currentFood.Title + "\n");
                    }
                }
            }
            while (HasNextFood())
            {
                currentFood = NextFood();
                if (currentFood.IsSetMenu == true)
                {
                    for (int i = currentFood.getSize()-1; i > -1; i--)
                    {
                        if (currentFood.FoodList[i] == mi.FoodList[0])
                        {
                            currentFood.FoodList.RemoveAt(i);
                            Console.WriteLine("Since " + mi.Title + " was deleted, it will be removed from " + currentFood.Title);
                        }
                    }
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

        public bool HasSetMeal()
        {
            foreach (MenuItem mi in itemList)
            {
                if (mi.IsSetMenu == true)
                    return true;
            }
            return false;
        }
    }
}
