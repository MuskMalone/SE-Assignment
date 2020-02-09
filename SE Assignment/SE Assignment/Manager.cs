using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Manager : Employee
    {
        private DateTime companyStartDate;

        public DateTime CompanyStartDate
        {
            get { return companyStartDate; }
            set { companyStartDate = value; }
        }

        public Manager(int id, string _name, string _nric, char _gender, string _status, 
                       DateTime _dateJoined, DateTime startDate)
        {
            EmployeeId = id;
            Name = _name;
            Nric = _nric;
            Gender = _gender;
            Status = _status;
            DateJoined = _dateJoined;
            companyStartDate = startDate;
        }


        public void ViewAllMenus(MenuCollection mc)
        {
            Console.WriteLine(mc.GetCurrent());
            while (mc.HasNextFood())
            {
                Console.WriteLine(mc.NextFood().ToString());
            }
        }
    }
}
