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
        private List<MenuItem> foodList;
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
        public List<MenuItem> FoodList {
            get { return foodList; }
            set { foodList = value; }
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

        public Receipt(int receiptNo, DateTime receiptDateTime, DateTime deliveryDateTime, List<MenuItem> _foodList, string paymentType, double amount)
        {
            ReceiptNo = receiptNo;
            ReceiptDateTime = receiptDateTime;
            DeliveryDateTime = deliveryDateTime;
            foodList = _foodList;
            PaymentType = paymentType;
            Amount = amount;
        }
        
        public string getReceiptDetails(Order o)
        {
            string receiptText = ("Receipt No: " + ReceiptNo + "\n" +
                    "Receipt Date & Time: " + ReceiptDateTime + "\n" +
                    "Delivery Date & Time: " + o.Eta + "\n" +
                    "Payment method: " + PaymentType + "\n" +
                    "Amount: $" + Amount + "\n");
            foreach (MenuItem mi in foodList)
            {
                receiptText += "\n" + mi.NewToString(false);
            }
            return receiptText;
        }

        public void viewAllReceipt(List<Receipt> rList, Order o)
        {
            foreach (Receipt r in rList)
            {
                Console.WriteLine("==================================");
                Console.WriteLine(r.getReceiptDetails(o));
            }
        }
    }
}
