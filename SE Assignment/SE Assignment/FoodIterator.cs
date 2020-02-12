using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public interface FoodIterator
    {
        MenuItem GetCurrent();

        MenuItem NextFood();

        bool HasNextFood();

        void AddFood(MenuItem m);

        void RemoveFood(int id);

        MenuItem GetMenuItem(int id);
    }
}
