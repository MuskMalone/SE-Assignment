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
        private double price;

        public FoodCollection(int id, string menuName, double _price)
        {
            menuID = id;
            name = menuName;
            price = _price;
        }

        public double GetPrice()
        {
            return price;
        }
        public int GetID()
        {
            return menuID;
        }
        public string GetName()
        {
            return name;
        }

        public List<Food> foodList = new List<Food>();
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
            string displayText = "[" + menuID + "] " + name + ", Size: " + size + ", Price: $" + price;
            displayText += "\n> " + GetCurrent().Title;
            while (HasNextFood())
            {
                displayText += "\n> " + NextFood().Title;
            }
            
            return displayText;
        }

        public void ListAllFood()
        {
            Console.WriteLine(GetCurrent());
            while (HasNextFood())
            {
                Console.WriteLine(NextFood().ToString());
            }
        }
        
        public double GetTotalAmount()
        {
            double amount = 0;

            for (int i = 0; i < size; i++)
            {
                amount += foodList[i].Price;
            }

            return amount;
        }
    }
}
