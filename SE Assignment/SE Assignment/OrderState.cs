using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    interface OrderState
    {
        void prepareOrder();

        void completeOrder();

        void dispatchOrder();

        void confirmOrder();

        void archiveOrder();
    }
}
