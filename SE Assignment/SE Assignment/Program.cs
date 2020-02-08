using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager me = new Manager(1, "Cheng En", "T0034912C", 'M', "Present", DateTime.Now, DateTime.Now);
            FoodIterator dMenu = me.CreateFoodIterator(1, "Wombo Combo");
            Food f1 = new Food(1, "Hamburger", "Fast Food", 4.5);
            Food f2 = new Food(2, "Bingsu", "Dessert", 6.9);
            Food f3 = new Food(3, "Mountain Dew", "Drinks", 1.5);
            dMenu.AddFood(f1);
            dMenu.AddFood(f2);
            dMenu.AddFood(f3);
            me.ViewAllMenus();
            dMenu.RemoveFood(2);
            FoodIterator testMenu = me.CreateFoodIterator(2, "If u see this menu, it works!");
            Food f4 = new Food(4, "Test", "Test", 0);
            testMenu.AddFood(f4);
            me.ViewAllMenus();

            Console.ReadLine();
        }
    }
}
