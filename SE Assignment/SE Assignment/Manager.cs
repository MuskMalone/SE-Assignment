using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Manager : Employee
    {
        private OrderCollection orderCollection;
        private DateTime companyStartDate;

        public DateTime CompanyStartDate
        {
            get { return companyStartDate; }
            set { companyStartDate = value; }
        }

        public Manager() { }

        public Manager(int id, string _name, string _nric, char _gender, string _status,
                       OrderCollection oc, DateTime _dateJoined, DateTime startDate)
        {
            employeeID = id;
            name = _name;
            nric = _nric;
            gender = _gender;
            status = _status;
            orderCollection = oc;
            dateJoined = _dateJoined;
            companyStartDate = startDate;
        }
        
        public string getManagerDetails()
        {
            return ("Employee ID: " + employeeID + "\n" +
                    "Name : " + name + "\n" +
                    "NRIC : " + nric + "\n" +
                    "Gender : " + gender + "\n" +
                    "Status : " + status + "\n" +
                    "Date Joined : " + dateJoined + "\n" +
                    "Company Start Date : " + companyStartDate + "\n");
        }        

        public void viewAllManagers(List<Manager> mList)
        {
            Console.WriteLine("\n======= MANAGER DETAILS =======");
            foreach (Manager m in mList)
            {
                Console.WriteLine(m.getManagerDetails());
            }
        }

        public FoodIterator CreateFoodIterator()
        {
            FoodIterator mc = new FoodCollection();
            Console.WriteLine("Created Menu Successfully!");
            return mc;
        }

        public void displayAllFood(FoodIterator menu, int type)
        {
            // 1 - Alacarte | 2 - SetMenus | 0 - All
            if (type == 1)
            {
                if (menu.GetCurrent().IsSetMenu == false)
                    Console.WriteLine(menu.GetCurrent().NewToString(true));
                while (menu.HasNextFood())
                {
                    if (menu.NextFood().IsSetMenu == false)
                        Console.WriteLine(menu.GetCurrent().NewToString(true));
                }
            }
            else if (type ==2)
            {
                if (menu.GetCurrent().IsSetMenu == false)
                    Console.WriteLine(menu.GetCurrent().NewToString(true));
                while (menu.HasNextFood())
                {
                    if (menu.NextFood().IsSetMenu == false)
                        Console.WriteLine(menu.GetCurrent().NewToString(true));
                }
            }
            else if (type == 0)
            {
                Console.WriteLine(menu.GetCurrent().NewToString(true));
                while (menu.HasNextFood())
                {
                    Console.WriteLine(menu.NextFood().NewToString(true));

                }
            }

        }
    }
}
