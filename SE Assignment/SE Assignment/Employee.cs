using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Employee
    {
        private int employeeID;
        private string name;
        private string nric;
        private char gender;
        private string status;
        private DateTime dateJoined;

        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string NRIC { get; set; }
        public char Gender { get; set; }
        public string Status { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
