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
            var testMenu = new FoodCollection();
            Food f1 = new Food("Banana", "Fruit", 1.5);
            Food f2 = new Food("Chicken Rice", "Meal", 2.5);
            testMenu.AddFood(f1);
            testMenu.AddFood(f2);
            Console.WriteLine(testMenu.NextFood().Title);
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
