using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Customer
    {
        private OrderCollection orderCollection;
        private List<Order> OrderList = new List<Order>();

        private Receipt receipt;
        
        private string name;
        private int customerId;
        private int phoneNumber;
        private string email;
        private string address;

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

        public void placeOrder()
        {

        }

        public List<Order> GetAllOrdersState()
        {
            List<Order> oList = new List<Order>();
            for (int i = 0; i < OrderList.Count(); i++)
            {
                if (OrderList[i].OrderStatus == "new" ||
                    OrderList[i].OrderStatus == "ready" ||
                    OrderList[i].OrderStatus == "preparing" ||
                    OrderList[i].OrderStatus == "dispatched" ||
                    OrderList[i].OrderStatus == "delivered")
                {
                    oList.Add(OrderList[i]);
                }
            }
            return oList;
        }

        public void viewAllOrderStatuses()
        {
            Console.WriteLine("========= YOUR ORDER STATUSES ========\n");
            Console.WriteLine(GetAllOrdersState());
        }


        public void updateOrderStatus()
        {

        }

        public void cancelOrder()
        {

        }

        public void rateRestaurant()
        {

        }
    }
}
