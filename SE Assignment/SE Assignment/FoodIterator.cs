using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public interface FoodIterator
    {
        int GetID();

        string GetName();

        Food GetCurrent();

        Food NextFood();

        bool HasNextFood();

        void AddFood(Food f);

        void EditFood(int id, Food f);

        void RemoveFood(int id);
    }
}
