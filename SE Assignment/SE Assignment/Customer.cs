using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Customer : Observer
    {
        private OrderCollection orderCollection;
        private List<Order> OrderList = new List<Order>();

        private Receipt receipt;
        
        private string name;
        private int customerId;
        private int phoneNumber;
        private string email;
        private string address;

        public List<MenuItem> custfoodList = new List<MenuItem>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Customer(){ }

        public Customer(string name, int customerId, int phoneNumber, string email, string address)
        {
            Name = name;
            CustomerId = customerId;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public double GetCartTotal()
        {
            double amount = 0;

            foreach (MenuItem item in custfoodList)
            {
                amount += item.Price;
            }

            return amount;
        }

        public void placeOrder()
        {

        }      

        public void update(string orderstatus)
        {
            string updateMessage = "Customer " + Convert.ToString(customerId) + ", " + name + ", your order is in " + orderstatus + " state.";
            Console.WriteLine(updateMessage);
        }

        public void cancelOrder()
        {

        }

        public void rateRestaurant()
        {

        }

        public void ConfirmdOrder(int orderid)
        {
            orderCollection.GetOrder(orderid).getCurrentState().confirmOrder();
        }
    }
}
