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
        /*private string orderStatus;
        public String OrderStatus { get; set; }
        public readonly int OrderID;

        public Order(int id, string status) //status should be removed 
        {
            OrderID = id;
            OrderStatus = status;
            //OrderStatus = "new";
        }*/

        public Order(int id, string status) //status should be removed 
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
        
        public void registerCustomer(Customer c)
        {
            customer = c;
        }

        public void removeCustomer()
        {
            customer = null;
            Console.WriteLine("Customer has been removed");
        }

        public void notifyCustomer()
        {
            if (customer != null)
            {
                customer.update(OrderStatus);
            }
            Console.WriteLine("");
        }
    }
}
