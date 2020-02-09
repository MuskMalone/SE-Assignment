using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Employee
    {
        protected string Name;
        protected int EmployeeId;
        protected string Nric;
        protected char Gender;
        protected DateTime DateJoined;
        protected string Status;
        
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
