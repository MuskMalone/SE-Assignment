using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Receipt
    {
        private int receiptNo;
        private DateTime receiptDateTime;
        private DateTime deliveryDateTime;
        private List<FoodIterator> menuItem;
        private List<Food> foodItem;
        private string paymentType;
        private double amount;

        public int ReceiptNo {
            get { return receiptNo; }
            set { receiptNo = value; }
        }
        public DateTime ReceiptDateTime {
            get { return receiptDateTime; }
            set { receiptDateTime = value; }
        }
        public DateTime DeliveryDateTime {
            get { return deliveryDateTime; }
            set { deliveryDateTime = value; }
        }
        public List<FoodIterator> MenuItem {
            get { return menuItem; }
            set { menuItem = value; }
        }
        public List<Food> FoodItem
        {
            get { return foodItem; }
            set { foodItem = value; }
        }
        public string PaymentType {
            get { return paymentType; }
            set { paymentType = value; }
        }
        public double Amount {
            get { return amount; }
            set { amount = value; }
        }

        public Receipt() { }

        public Receipt(int receiptNo, DateTime receiptDateTime, DateTime deliveryDateTime, List<FoodIterator> _menuItem, List<Food> _foodItem, string paymentType, double amount)
        {
            ReceiptNo = receiptNo;
            ReceiptDateTime = receiptDateTime;
            DeliveryDateTime = deliveryDateTime;
            menuItem = _menuItem;
            foodItem = _foodItem;
            PaymentType = paymentType;
            Amount = amount;
        }
        
        public string getReceiptDetails()
        {
            string receiptText = ("Receipt No: " + ReceiptNo + "\n" +
                    "Receipt Date & Time: " + ReceiptDateTime + "\n" +
                    "Delivery Date & Time: " + DeliveryDateTime + "\n" +
                    "Payment method: " + PaymentType + "\n" +
                    "Amount: $" + Amount + "\n");
            foreach (FoodIterator menu in menuItem)
            {
                receiptText += "\n" + menu.ToString();
            }
            
            foreach (Food food in foodItem)
            {
                receiptText += "\n" + food.ToString();
            }
            return receiptText;
        }

        public void viewAllReceipt(List<Receipt> rList)
        {
            foreach (Receipt r in rList)
            {
                Console.WriteLine("==================================");
                Console.WriteLine(r.getReceiptDetails());
            }
        }
    }
}
