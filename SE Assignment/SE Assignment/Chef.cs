using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Chef: Employee
    {
        private OrderCollection ordercollection;
        public Chef(string name, int id, string nric, char gender, DateTime datejoined, string status, OrderCollection oc)
        {
            Name = name;
            EmployeeId = id;
            Nric = nric;
            Gender = gender;
            DateJoined = datejoined;
            Status = status;
            ordercollection = oc;
        }

        public void PrepareOrder()
        {

        }
    }
}
