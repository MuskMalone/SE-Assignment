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
        private string paymentItem;
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
        public string PaymentItem {
            get { return paymentItem; }
            set { paymentItem = value; }
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

        public Receipt(int receiptNo, DateTime receiptDateTime, DateTime deliveryDateTime, string paymentItem, string paymentType, double amount)
        {
            ReceiptNo = receiptNo;
            ReceiptDateTime = receiptDateTime;
            DeliveryDateTime = deliveryDateTime;
            PaymentItem = paymentItem;
            PaymentType = paymentType;
            Amount = amount;
        }
        
        public string getReceiptDetails()
        {
            return ("Receipt No: " + ReceiptNo + "\n" + 
                    "Receipt Date & Time: " + ReceiptDateTime + "\n" +
                    "Delivery Date & Time: " + DeliveryDateTime + "\n" +
                    "Items paid: " + PaymentItem + "\n" +
                    "Payment method: " + PaymentType + "\n" +
                    "Amount: $" + Amount);
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
