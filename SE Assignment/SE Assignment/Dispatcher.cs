using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Dispatcher : Employee
    {
        private double totalCommision;

        public double TotalCommission
        {
            get { return totalCommision; }
            set { totalCommision = value; }
        }

        public void dispatchOrder()
        {

        }
    }
}
