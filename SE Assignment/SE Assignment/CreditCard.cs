using System;
namespace SE_Assignment
{
    public class CreditCard:PaymentStrategy
    {
		private String name;
		private String cardNumber;
		private String cvc;
		private String dateOfExpiry;

		public CreditCard(String nm, String ccNum, String cvc, String expiryDate)
		{
			this.name = nm;
			this.cardNumber = ccNum;
			this.cvc = cvc;
			this.dateOfExpiry = expiryDate;
		}


	public void pay(double amount)
		{
			Console.WriteLine(amount + " paid with credit/debit card");
		}


	}
}
