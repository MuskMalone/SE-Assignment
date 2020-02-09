using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class MenuCollection : FoodAggregate
    {
        List<FoodIterator> menuList = new List<FoodIterator>();
        int position = 0;

        public FoodIterator GetCurrent()
        {
            return menuList[position];
        }

        public FoodIterator NextFood()
        {
            if (position < menuList.Count() - 1)
            {
                position++;
                return menuList[position];
            }
            position = 0;
            return null;
        }

        public bool HasNextFood()
        {
            if (position < menuList.Count() - 1)
                return true;
            position = 0;
            return false;
        }

        public FoodIterator CreateFoodIterator(int id, string menuName)
        {
            FoodIterator fi = new FoodCollection(id, menuName);
            menuList.Add(fi);
            Console.WriteLine("Created Menu Successfully!");
            return fi;
        }

        public void editMenu(int id, FoodIterator fc)
        {
            for (int i = 0; i < menuList.Count() - 1; i++)
            {
                if (menuList[i].GetID() == id)
                {
                    menuList[i] = fc;
                    Console.WriteLine("Menu Successfully Edited!");
                }
            }
        }

        public void deleteMenu(int id)
        {
            for (int i = 0; i < menuList.Count(); i++)
            {
                if (menuList[i].GetID() == id)
                {
                    string removedMenu = menuList[i].GetName();
                    menuList.RemoveAt(i);
                    Console.WriteLine("Successfully Deleted" + removedMenu + "!");
                }
            }
        }

        public void ViewAllFood(FoodIterator fc)
        {
            Console.WriteLine(fc.GetCurrent());
            while (fc.HasNextFood())
            {
                Console.WriteLine(fc.NextFood().ToString());
            }
        }
    }
}
