using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Chef : Employee
    {
        private OrderCollection ordercollection;
        public Chef(string n, int id, string ic, char gender, DateTime datejoined, string status, OrderCollection oc)
        {
            name = n;
            EmployeeID = id;
            nric = ic;
            Gender = gender;
            DateJoined = datejoined;
            Status = status;
            ordercollection = oc;
        }

        public OrderCollection getOrderCollection() { return ordercollection; }
        public void PrepareOrder()
        {

        }
    }
}
