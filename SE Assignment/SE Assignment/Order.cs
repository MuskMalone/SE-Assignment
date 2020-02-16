using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public class Order : Subject
    {
        public string OrderStatus { get; set; }
        public readonly int OrderID;      
        
        private OrderState newState;
        private OrderState preparingState;
        private OrderState readyState;
        private OrderState dispatchedState;
        private OrderState deliveredState;
        private OrderState cancelledState;

        private OrderState currentState;
        private Customer customer;
        private List<MenuItem> foodList = new List<MenuItem>();
        private DateTime dateCreated;
        private DateTime eta;
        private double totalPrice;

        public Order(int id, string status, List<MenuItem> fL, DateTime created, DateTime estimated, double tP) //status should be removed 
        {
            OrderID = id;
            OrderStatus = "new";
            newState = new NewState(this);
            preparingState = new PreparingState(this);
            readyState = new ReadyState(this);
            dispatchedState = new DispatchedState(this);
            deliveredState = new DeliveredState(this);
            cancelledState = new CancelledState(this);
            setState(newState);
            foodList = fL;
            dateCreated = created;
            eta = estimated;
            totalPrice = tP;
        }
        public void setState(OrderState os)
        {
            currentState = os;
            OrderStatus = os.getStateName();
            notifyCustomer();
        }
        public OrderState getCurrentState()
        {
            return currentState;
        }

        public OrderState getNewState() { return newState; }
        public OrderState getPreparingState() { return preparingState; }
        public OrderState getReadyState() { return readyState; }
        public OrderState getDispatchedState() { return dispatchedState; }
        public OrderState getDeliveredState() { return deliveredState; }
        public OrderState getCancelledState() { return cancelledState; }
        public DateTime Eta { get { return eta; } set { eta = value; } }

        public void registerCustomer(Customer c)
        {
            customer = c;
            // Code
        }

        public bool isCancelValid()
        {
            if (DateTime.Compare(dateCreated, eta) > 0)
                return true;
            return false;
        }
        public void removeCustomer()
        {
            customer = null;
            Console.WriteLine("Customer has been removed");
            // Code
        }

        public void notifyCustomer()
        {
            if (customer != null)
            {
                customer.update(OrderStatus);
            }
            Console.WriteLine("");
            // Code
        }

        public string displayOrderDetails()
        {
            string detailsText = ("Order No: " + OrderID + "\n" +
                    "Payment method: " + OrderStatus + "\n" +
                    "Order Date & Time: " + dateCreated + "\n" +
                    "Delivery Date & Time: " + eta + "\n" +
                    "Amount: $" + totalPrice + "\n");
            foreach (MenuItem mi in foodList)
            {
                detailsText += "\n" + mi.NewToString(false);
            }
            return detailsText;
        }
    }
}
