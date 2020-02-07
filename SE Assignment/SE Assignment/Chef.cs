using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Chef: Employee
    {
        public Chef(string name, int id, string nric, char gender, DateTime datejoined, string status)
        {
            Name = name;
            EmployeeId = id;
            Nric = nric;
            Gender = gender;
            DateJoined = datejoined;
            Status = status;
        }

        public void PrepareOrder()
        {

        }
    }
}
