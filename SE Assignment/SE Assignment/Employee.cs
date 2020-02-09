using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Employee
    {        
        private string name { get; set; }
        private int employeeID { get; set; }
        private string nric { get; set; }
        private char gender { get; set; }
        private DateTime dateJoined { get; set; }
        private string status { get; set; }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string NRIC
        {
            get { return nric; }
            set { nric = value; }
        }

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime DateJoined
        {
            get { return dateJoined; }
            set { dateJoined = value; }
        }
    }
}
