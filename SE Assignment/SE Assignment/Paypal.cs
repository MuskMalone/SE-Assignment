using System;
namespace SE_Assignment
{
    public class Paypal:PaymentStrategy
    {
        
		private String currency;
		private String recipientName;
        //test

		public Paypal(String curr, String name)
		{
			this.currency = curr;
			this.recipientName = name;
		}

	
	    public void pay(double amount)
		{
			Console.WriteLine(amount + " paid using Paypal.");
		}
	}
}
