using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Dispatcher : Employee
    {
        private Order order;
        private OrderCollection orderCollection;

        private double totalCommission;

        public double TotalCommission
        {
            get { return totalCommision; }
            set { totalCommision = value; }
        }

        public void dispatchOrder(Order order)
        {
            // Code
            order.OrderStatus = "dispatched";
        }

        public Dispatcher() { }

        public Dispatcher(string name, int employeeId, string nric, char gender, DateTime datejoined, string status, OrderCollection oc)
        {
            Name = name;
            EmployeeID = employeeId;
            NRIC = nric;
            Gender = gender;
            DateJoined = datejoined;
            Status = status;
            orderCollection = oc;
        }
        
        public string getDispatcherDetails()
        {
            return ("Employee ID: " + EmployeeID + "\n" +
                    "Name : " + Name + "\n" +
                    "NRIC : " + NRIC + "\n" +
                    "Gender : " + Gender + "\n" +
                    "Status : " + Status + "\n" +
                    "Date Joined : " + DateJoined + "\n" +
                    "Total comission : " + TotalCommission);
        }

        public void viewAllDispatchers(List<Dispatcher> dList)
        {
            foreach (Dispatcher d in dList)
            {
                Console.WriteLine("==================================");
                Console.WriteLine(d.getDispatcherDetails());
            }
        }

        public double calculateCommission(Order o, double totalCommission)
        {
            // Reset commission if new month
            if (DateTime.Now.Day == 1 && order.OrderStatus != "delivered")
            {
                totalCommission = 0;
            }
            // Assign commission if delivery successful on new month
            else if (DateTime.Now.Day == 1 && order.OrderStatus == "delivered")
            {
                totalCommission = totalCommission + 1;
            }
            // Assign commission if delivery successful regardless 
            else if (DateTime.Now.Day != 1 && order.OrderStatus == "delivered")
            {
                totalCommission = totalCommission + 1;
            }
            return totalCommission;
        }
    }
}
