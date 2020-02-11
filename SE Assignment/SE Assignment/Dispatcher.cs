using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SE_Assignment
{
    public class Dispatcher : Employee
    {
        private Order order;
        private OrderCollection orderCollection;

        private double totalCommision;

        public double TotalCommission
        {
            get { return totalCommision; }
            set { totalCommision = value; }
        }

        public Dispatcher() { }

        public Dispatcher(string _name, int _employeeId, string _nric, 
                          char _gender, DateTime _datejoined, string _status, 
                          OrderCollection oc)
        {
            name = _name;
            employeeID = _employeeId;
            nric = _nric;
            gender = _gender;
            dateJoined = _datejoined;
            status = _status;
            orderCollection = oc;
        }
        
        public string getDispatcherDetails()
        {
            return ("Employee ID: " + employeeID + "\n" +
                    "Name : " + name + "\n" +
                    "NRIC : " + nric + "\n" +
                    "Gender : " + gender + "\n" +
                    "Status : " + status + "\n" +
                    "Date Joined : " + dateJoined + "\n" +
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

        public string getCompletedOrders(Order o)
        {
            return ("======== Orders ready to be dispatched ======== \n" +
                    "Order No." + o.OrderID + "\n" +
                    "Status:" + o.OrderStatus);
        }

        public void viewCompletedOrders(Order o)
        {
            o.getCurrentState();
            Console.WriteLine(o.getCurrentState());
        }

        public void dispatchOrder()
        {

        }

        // TO BE IMPLEMENTED
        /*
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
        */
    }
}
