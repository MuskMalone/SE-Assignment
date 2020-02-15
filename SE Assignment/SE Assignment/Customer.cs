using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Customer : Observer
    {
        private Receipt receipt;
        
        private string name;
        private int customerId;
        private int phoneNumber;
        private string email;
        private string address;

        //public List<Food> custfoodList = new List<Food>();
        //public List<FoodIterator> custmenuList = new List<FoodIterator>();

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

        //public double GetcustfoodListTotalAmount()
        //{
        //    double amount = 0;

        //    foreach (Food food in custfoodList)
        //    {
        //        if (food != null)
        //            amount += food.Price;
        //    }

        //    return amount;
        //}


        //public double GetcustmenuListListTotalAmount()
        //{
        //    double amount = 0;

        //    foreach (FoodIterator set in custmenuList)
        //    {
        //        if (set != null)
        //            amount += set.GetPrice();
        //    }

        //    return amount;
        //}

        public void updateOrderStatus()
        {

        }

        public void placeOrder()
        {

        }

        public void viewOrderStatus()
        {

        }

        public void update()
        {
            Console.WriteLine("Your order has advanced to the next phase");
        }

        public void cancelOrder()
        {

        }

        public void rateRestaurant()
        {

        }
    }
}
