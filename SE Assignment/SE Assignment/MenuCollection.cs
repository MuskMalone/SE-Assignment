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

        public int GetCount()
        {
            return menuList.Count();
        }
        public FoodIterator GetCurrent()
        {
            return menuList[position];
        }

        public FoodIterator NextMenu()
        {
            if (position < menuList.Count()-1)
            {
                position++;
                return menuList[position];
            }
            position = 0;
            return null;
        }

        public bool HasNextMenu()
        {
            if (position < menuList.Count()-1)
                return true;
            position = 0;
            return false;
        }

        public FoodIterator CreateFoodIterator(int id, string menuName, double price)
        {
            FoodIterator fi = new FoodCollection(id, menuName, price);
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

        public void ListAllMenus()
        {
            Console.WriteLine("================ Set Meals ===============\n");
            Console.WriteLine(GetCurrent().ToString());
            while (HasNextMenu())
            {
                Console.WriteLine();
                Console.WriteLine(NextMenu().ToString());
            }
        }

        public FoodIterator GetMenu(int id)
        {
            for (int i = 0; i < menuList.Count(); i++)
            {
                if (GetCurrent().GetID() == id)
                    return GetCurrent();
                else
                {
                    while (HasNextMenu())
                    {
                        if (NextMenu().GetID() == id)
                            return GetCurrent();
                    }
                }
            }
            return null;
        }
    }
}
