using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    interface Subject
    {
        void registerCustomer(Customer c);
        void removeCustomer(Customer c);
        void notifyCustomer(Customer c);
    }
}
