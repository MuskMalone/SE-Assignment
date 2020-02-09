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

        public Chef() { }
        public Chef(string n, int id, string ic, char _gender, DateTime _datejoined, string _status, OrderCollection oc)
        {
            name = n;
            employeeID = id;
            nric = ic;
            gender = _gender;
            dateJoined = _datejoined;
            status = _status;
            ordercollection = oc;
        }

        public OrderCollection getOrderCollection() { return ordercollection; }
        
        public void PrepareOrder()
        {

        }
    }
}
